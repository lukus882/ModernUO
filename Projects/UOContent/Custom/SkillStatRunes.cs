/*********************************
 * Written by ImaNewb            *
 * FileName: SkillStatRunes.cs   *
 * Created for use with ModernUO *
 * Date: July 17, 2024           *
 ********************************/

using ModernUO.Serialization;
using Server.Items;

namespace Server.Custom
{
    [SerializationGenerator(0, false)]
    public abstract partial class StatRune : Item
    {
        public abstract void ApplyEffect(Mobile from);

        public StatRune(int itemID, int hue, string name) : base(itemID)
        {
            Movable = true;
            Hue = hue;
            Name = name;
            LootType = LootType.Blessed;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            ApplyEffect(from);
        }

        protected void ApplyStatEffect(Mobile from, string statName)
        {
            from.SendMessage($"Your {statName} has been increased to 85.");
            Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 9, 32, Hue, 0, 5022, 0);
            Effects.PlaySound(from.Location, from.Map, 0x1F7);
            this.Delete();
        }
    }

    [SerializationGenerator(0, false)]
    public partial class StrengthRune : StatRune
    {
        [Constructible]
        public StrengthRune() : base(0x1F14, 28, "Strength Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            if (from.Str < 85)
            {
                from.Str = 85;
                ApplyStatEffect(from, "strength");
            }
            else
            {
                from.SendMessage("Your strength is already 85 or higher.");
            }
        }
    }

    [SerializationGenerator(0, false)]
    public partial class DexterityRune : StatRune
    {
        [Constructible]
        public DexterityRune() : base(0x1F14, 68, "Dexterity Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            if (from.Dex < 85)
            {
                from.Dex = 85;
                ApplyStatEffect(from, "dexterity");
            }
            else
            {
                from.SendMessage("Your dexterity is already 85 or higher.");
            }
        }
    }

    [SerializationGenerator(0, false)]
    public partial class IntelligenceRune : StatRune
    {
        [Constructible]
        public IntelligenceRune() : base(0x1F14, 98, "Intelligence Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            if (from.Int < 85)
            {
                from.Int = 85;
                ApplyStatEffect(from, "intelligence");
            }
            else
            {
                from.SendMessage("Your intelligence is already 85 or higher.");
            }
        }
    }

    [SerializationGenerator(0, false)]
    public abstract partial class SkillRune : Item
    {
        public abstract void ApplyEffect(Mobile from);

        public SkillRune(int itemID, int hue, string name) : base(itemID)
        {
            Movable = true;
            Hue = hue;
            Name = name;
            LootType = LootType.Blessed;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            ApplyEffect(from);
        }

        protected void ApplySkillEffect(Mobile from, SkillName skill, string skillName)
        {
            var skillValue = from.Skills[skill].Base;
            if (skillValue < 85.0)
            {
                from.Skills[skill].Base = 85.0;
                from.SendMessage($"Your {skillName} skill has been increased to 85.");
                Effects.SendLocationParticles(EffectItem.Create(from.Location, from.Map, EffectItem.DefaultDuration), 0x376A, 9, 32, Hue, 0, 5022, 0);
                Effects.PlaySound(from.Location, from.Map, 0x1F7);
                this.Delete();
            }
            else
            {
                from.SendMessage($"Your {skillName} skill is already 85 or higher.");
            }
        }
    }

    // Skill Runes
    [SerializationGenerator(0, false)]
    public partial class DiscordanceRune : SkillRune
    {
        [Constructible]
        public DiscordanceRune() : base(0x1F14, 88, "Discordance Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Discordance, "discordance");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MusicianshipRune : SkillRune
    {
        [Constructible]
        public MusicianshipRune() : base(0x1F14, 88, "Musicianship Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Musicianship, "musicianship");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class PeacemakingRune : SkillRune
    {
        [Constructible]
        public PeacemakingRune() : base(0x1F14, 88, "Peacemaking Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Peacemaking, "peacemaking");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ProvocationRune : SkillRune
    {
        [Constructible]
        public ProvocationRune() : base(0x1F14, 88, "Provocation Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Provocation, "provocation");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class AnatomyRune : SkillRune
    {
        [Constructible]
        public AnatomyRune() : base(0x1F14, 88, "Anatomy Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Anatomy, "anatomy");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ArcheryRune : SkillRune
    {
        [Constructible]
        public ArcheryRune() : base(0x1F14, 88, "Archery Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Archery, "archery");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class FencingRune : SkillRune
    {
        [Constructible]
        public FencingRune() : base(0x1F14, 88, "Fencing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Fencing, "fencing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class FocusRune : SkillRune
    {
        [Constructible]
        public FocusRune() : base(0x1F14, 88, "Focus Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Focus, "focus");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class HealingRune : SkillRune
    {
        [Constructible]
        public HealingRune() : base(0x1F14, 88, "Healing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Healing, "healing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MaceFightingRune : SkillRune
    {
        [Constructible]
        public MaceFightingRune() : base(0x1F14, 88, "Mace Fighting Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Macing, "mace fighting");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ParryingRune : SkillRune
    {
        [Constructible]
        public ParryingRune() : base(0x1F14, 88, "Parrying Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Parry, "parrying");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class SwordsmanshipRune : SkillRune
    {
        [Constructible]
        public SwordsmanshipRune() : base(0x1F14, 88, "Swordsmanship Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Swords, "swordsmanship");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class TacticsRune : SkillRune
    {
        [Constructible]
        public TacticsRune() : base(0x1F14, 88, "Tactics Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Tactics, "tactics");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ThrowingRune : SkillRune
    {
        [Constructible]
        public ThrowingRune() : base(0x1F14, 88, "Throwing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Throwing, "throwing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class WrestlingRune : SkillRune
    {
        [Constructible]
        public WrestlingRune() : base(0x1F14, 88, "Wrestling Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Wrestling, "wrestling");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class BushidoRune : SkillRune
    {
        [Constructible]
        public BushidoRune() : base(0x1F14, 88, "Bushido Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Bushido, "bushido");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ChivalryRune : SkillRune
    {
        [Constructible]
        public ChivalryRune() : base(0x1F14, 88, "Chivalry Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Chivalry, "chivalry");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class EvaluatingIntelligenceRune : SkillRune
    {
        [Constructible]
        public EvaluatingIntelligenceRune() : base(0x1F14, 88, "Evaluating Intelligence Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.EvalInt, "evaluating intelligence");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ImbuingRune : SkillRune
    {
        [Constructible]
        public ImbuingRune() : base(0x1F14, 88, "Imbuing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Imbuing, "imbuing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MageryRune : SkillRune
    {
        [Constructible]
        public MageryRune() : base(0x1F14, 88, "Magery Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Magery, "magery");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MeditationRune : SkillRune
    {
        [Constructible]
        public MeditationRune() : base(0x1F14, 88, "Meditation Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Meditation, "meditation");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MysticismRune : SkillRune
    {
        [Constructible]
        public MysticismRune() : base(0x1F14, 88, "Mysticism Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Mysticism, "mysticism");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class NecromancyRune : SkillRune
    {
        [Constructible]
        public NecromancyRune() : base(0x1F14, 88, "Necromancy Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Necromancy, "necromancy");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class NinjitsuRune : SkillRune
    {
        [Constructible]
        public NinjitsuRune() : base(0x1F14, 88, "Ninjitsu Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Ninjitsu, "ninjitsu");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ResistingSpellsRune : SkillRune
    {
        [Constructible]
        public ResistingSpellsRune() : base(0x1F14, 88, "Resisting Spells Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.MagicResist, "resisting spells");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class SpellweavingRune : SkillRune
    {
        [Constructible]
        public SpellweavingRune() : base(0x1F14, 88, "Spellweaving Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Spellweaving, "spellweaving");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class SpiritSpeakRune : SkillRune
    {
        [Constructible]
        public SpiritSpeakRune() : base(0x1F14, 88, "Spirit Speak Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.SpiritSpeak, "spirit speak");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class BeggingRune : SkillRune
    {
        [Constructible]
        public BeggingRune() : base(0x1F14, 88, "Begging Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Begging, "begging");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ForensicEvaluationRune : SkillRune
    {
        [Constructible]
        public ForensicEvaluationRune() : base(0x1F14, 88, "Forensic Evaluation Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Forensics, "forensic evaluation");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ItemIdentificationRune : SkillRune
    {
        [Constructible]
        public ItemIdentificationRune() : base(0x1F14, 88, "Item Identification Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.ItemID, "item identification");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class TasteIdentificationRune : SkillRune
    {
        [Constructible]
        public TasteIdentificationRune() : base(0x1F14, 88, "Taste Identification Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.TasteID, "taste identification");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class DetectingHiddenRune : SkillRune
    {
        [Constructible]
        public DetectingHiddenRune() : base(0x1F14, 88, "Detecting Hidden Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.DetectHidden, "detecting hidden");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class HidingRune : SkillRune
    {
        [Constructible]
        public HidingRune() : base(0x1F14, 88, "Hiding Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Hiding, "hiding");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class LockpickingRune : SkillRune
    {
        [Constructible]
        public LockpickingRune() : base(0x1F14, 88, "Lockpicking Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Lockpicking, "lockpicking");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class PoisoningRune : SkillRune
    {
        [Constructible]
        public PoisoningRune() : base(0x1F14, 88, "Poisoning Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Poisoning, "poisoning");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class RemoveTrapRune : SkillRune
    {
        [Constructible]
        public RemoveTrapRune() : base(0x1F14, 88, "Remove Trap Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.RemoveTrap, "remove trap");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class SnoopingRune : SkillRune
    {
        [Constructible]
        public SnoopingRune() : base(0x1F14, 88, "Snooping Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Snooping, "snooping");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class StealingRune : SkillRune
    {
        [Constructible]
        public StealingRune() : base(0x1F14, 88, "Stealing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Stealing, "stealing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class StealthRune : SkillRune
    {
        [Constructible]
        public StealthRune() : base(0x1F14, 88, "Stealth Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Stealth, "stealth");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class AlchemyRune : SkillRune
    {
        [Constructible]
        public AlchemyRune() : base(0x1F14, 88, "Alchemy Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Alchemy, "alchemy");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class ArmsLoreRune : SkillRune
    {
        [Constructible]
        public ArmsLoreRune() : base(0x1F14, 88, "Arms Lore Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.ArmsLore, "arms lore");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class BlacksmithingRune : SkillRune
    {
        [Constructible]
        public BlacksmithingRune() : base(0x1F14, 88, "Blacksmithing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Blacksmith, "blacksmithing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class BowcraftFletchingRune : SkillRune
    {
        [Constructible]
        public BowcraftFletchingRune() : base(0x1F14, 88, "Bowcraft and Fletching Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Fletching, "bowcraft and fletching");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class CarpentryRune : SkillRune
    {
        [Constructible]
        public CarpentryRune() : base(0x1F14, 88, "Carpentry Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Carpentry, "carpentry");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class CartographyRune : SkillRune
    {
        [Constructible]
        public CartographyRune() : base(0x1F14, 88, "Cartography Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Cartography, "cartography");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class CookingRune : SkillRune
    {
        [Constructible]
        public CookingRune() : base(0x1F14, 88, "Cooking Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Cooking, "cooking");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class InscriptionRune : SkillRune
    {
        [Constructible]
        public InscriptionRune() : base(0x1F14, 88, "Inscription Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Inscribe, "inscription");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class LumberjackingRune : SkillRune
    {
        [Constructible]
        public LumberjackingRune() : base(0x1F14, 88, "Lumberjacking Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Lumberjacking, "lumberjacking");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class MiningRune : SkillRune
    {
        [Constructible]
        public MiningRune() : base(0x1F14, 88, "Mining Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Mining, "mining");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class TailoringRune : SkillRune
    {
        [Constructible]
        public TailoringRune() : base(0x1F14, 88, "Tailoring Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Tailoring, "tailoring");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class TinkeringRune : SkillRune
    {
        [Constructible]
        public TinkeringRune() : base(0x1F14, 88, "Tinkering Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Tinkering, "tinkering");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class AnimalLoreRune : SkillRune
    {
        [Constructible]
        public AnimalLoreRune() : base(0x1F14, 88, "Animal Lore Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.AnimalLore, "animal lore");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class AnimalTamingRune : SkillRune
    {
        [Constructible]
        public AnimalTamingRune() : base(0x1F14, 88, "Animal Taming Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.AnimalTaming, "animal taming");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class CampingRune : SkillRune
    {
        [Constructible]
        public CampingRune() : base(0x1F14, 88, "Camping Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Camping, "camping");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class FishingRune : SkillRune
    {
        [Constructible]
        public FishingRune() : base(0x1F14, 88, "Fishing Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Fishing, "fishing");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class HerdingRune : SkillRune
    {
        [Constructible]
        public HerdingRune() : base(0x1F14, 88, "Herding Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Herding, "herding");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class TrackingRune : SkillRune
    {
        [Constructible]
        public TrackingRune() : base(0x1F14, 88, "Tracking Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Tracking, "tracking");
        }
    }

    [SerializationGenerator(0, false)]
    public partial class VeterinaryRune : SkillRune
    {
        [Constructible]
        public VeterinaryRune() : base(0x1F14, 88, "Veterinary Rune") { }

        public override void ApplyEffect(Mobile from)
        {
            ApplySkillEffect(from, SkillName.Veterinary, "veterinary");
        }
    }
}
