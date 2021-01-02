
namespace ProjectGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Skeleton Skeleton = new Skeleton("Skeleton",5,5,5,5,5,5,5,5);

            Fight Round_one = new Fight();

            Round_one += Skeleton;

            Round_one.whosInFight();
        }
    }
}
