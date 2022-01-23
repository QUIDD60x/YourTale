using Terraria;
using Terraria.ModLoader;
namespace yourtale.Prefixes.Accessories

{
    public class Weighted : ModPrefix
    {
        public Weighted()
        {

        }
        public override bool Autoload(ref string name)
        {
            if (!base.Autoload(ref name))
            {
                return false;
            }


            mod.AddPrefix("Weighted", new Weighted());


            return false;
        }


        public override PrefixCategory Category
            => PrefixCategory.Accessory;










        public override void ModifyValue(ref float valueMult)
        {

            valueMult *= 2f;
        }

        public override float RollChance(Item item)
            => 0.1f;

        public override void Apply(Item item)
        {


            item.rare += 1;

        }


    }
}
