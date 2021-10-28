using System;
using System.Collections.Generic;
using Server.Targeting;

namespace Server.Spells.Mysticism
{
    public class SpellPlagueSpell : MysticSpell, ISpellTargetingMobile
    {
        private static readonly SpellInfo _info = new(
            "Spell Plague",
            "Vas Rel Jux Ort",
            -1,
            9002,
            Reagent.DaemonBone,
            Reagent.DragonsBlood,
            Reagent.Nightshade,
            Reagent.SulfurousAsh
        );

        private static readonly Dictionary<Mobile, SpellPlagueTimer> _table = new();

        public SpellPlagueSpell(Mobile caster, Item scroll = null) : base(caster, scroll, _info)
        {
        }

        public override SpellCircle Circle => SpellCircle.Seventh;

        public static void Initialize()
        {
            EventSink.PlayerDeath += OnPlayerDeath;
        }

        public override void OnCast()
        {
            Caster.Target = new SpellTargetMobile(this, TargetFlags.Harmful);
        }

        public void Target(Mobile targeted)
        {
            if (CheckHSequence(targeted))
            {
                SpellHelper.Turn(Caster, targeted);

                SpellHelper.CheckReflect(6, Caster, ref targeted);

                /* The target is hit with an explosion of chaos damage and then inflicted
                 * with the spell plague curse. Each time the target is damaged while under
                 * the effect of the spell plague, they may suffer an explosion of chaos
                 * damage. The initial chance to trigger the explosion starts at 90% and
                 * reduces by 30% every time an explosion occurs. Once the target is
                 * afflicted by 3 explosions or 8 seconds have passed, that spell plague
                 * is removed from the target. Spell Plague will stack with other spell
                 * plagues so that they are applied one after the other.
                 */

                VisualEffect(targeted);

                var damage = GetNewAosDamage(33, 1, 5, targeted);
                SpellHelper.Damage(this, targeted, damage, 0, 0, 0, 0, 0);

                var timer = new SpellPlagueTimer(this, targeted);

                if (_table.TryGetValue(targeted, out var oldtimer))
                {
                    oldtimer.SetNext(timer);
                }
                else
                {
                    _table[targeted] = timer;
                    timer.StartPlague();
                }
            }

            FinishSequence();
        }

        public static bool RemoveEffect(Mobile m)
        {
            if (_table.Remove(m, out var timer))
            {
                timer.Stop();
                BuffInfo.RemoveBuff(m, BuffIcon.SpellPlague);
                return true;
            }

            return false;
        }

        public static void OnMobileDamaged(Mobile m)
        {
            if (m != null && _table.TryGetValue(m, out var context))
            {
                context.OnDamage();
            }
        }

        private static void OnPlayerDeath(Mobile m)
        {
            RemoveEffect(m);
        }

        private static void VisualEffect(Mobile to)
        {
            to.PlaySound(0x658);

            to.FixedParticles(0x3728, 1, 13, 0x26B8, 0x47E, 7, EffectLayer.Head, 0);
            to.FixedParticles(0x3779, 1, 15, 0x251E, 0x43, 7, EffectLayer.Head, 0);
        }

        private class SpellPlagueTimer : Timer
        {
            private readonly SpellPlagueSpell _owner;
            private readonly Mobile _target;
            private int _explosions;
            private DateTime _nextExplosion;
            private SpellPlagueTimer _next;

            public SpellPlagueTimer(SpellPlagueSpell owner, Mobile target) : base(TimeSpan.FromSeconds(8.0))
            {
                _owner = owner;
                _target = target;
            }

            public void SetNext(SpellPlagueTimer timer)
            {
                if (_next == null)
                {
                    _next = timer;
                }
                else
                {
                    _next.SetNext(timer);
                }
            }

            public void StartPlague()
            {
                BuffInfo.AddBuff(
                    _target,
                    new BuffInfo(BuffIcon.SpellPlague, 1031690, 1080167, TimeSpan.FromSeconds(8.5), _target)
                );

                _nextExplosion = Core.Now + TimeSpan.FromSeconds(1);
                Start();
            }

            public void OnDamage()
            {
                if (Core.Now < _nextExplosion)
                {
                    return;
                }

                var exploChance = 90 - _explosions * 30;

                var resist = _target.Skills.MagicResist.Fixed - 700;

                if (resist > 0)
                {
                    exploChance -= resist / 100 * 3;
                }

                if (exploChance > Utility.Random(100))
                {
                    VisualEffect(_target);

                    // TODO: Add SDI bonus for Core.EJ (Publish 96)
                    var damage = _owner.GetNewAosDamage(15 + _explosions * 3, 1, 5, _target);

                    _explosions++;
                    _nextExplosion = Core.Now + TimeSpan.FromSeconds(1);

                    SpellHelper.Damage(_owner, _target, damage, 0, 0, 0, 0, 0, 100);

                    if (_explosions >= 3)
                    {
                        Stop();
                        DoNextPlague();
                    }
                }
            }

            private void DoNextPlague()
            {
                if (_next != null)
                {
                    _table[_target] = _next;
                    _next.StartPlague();
                }
                else
                {
                    RemoveEffect(_target);
                }
            }

            protected override void OnTick()
            {
                DoNextPlague();
            }
        }
    }
}
