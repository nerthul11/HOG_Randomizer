using ItemChanger;

namespace HallOfGodsRandomizer.IC
{
    public class StatueItem : AbstractItem
    {
        public string hogId { get; set; }
        public string statueName { get; set; }
        public override void GiveImmediate(GiveInfo info)
        {
            /// <summary>
            /// Expected to read how many Statue_Marks of the hogID have been obtained and handle switches based 
            /// on marks obtained and randomizer settings.
            /// </summary>
        }
    }
}