namespace ConsumingWebApiOrderAssignment
{
    public class Program
    {
        private void menu()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("            Manage Item      Press :1            *");
            Console.WriteLine("            Manage Customres Press :2            *");
            Console.WriteLine("            Close App        Press :3            *");
            Console.WriteLine("**************************************************");

        }
        public static void Main(string[] args)
        {
            Program program = new Program();

        repeedAgain:
            program.menu();

            int switch_on = int.Parse(Console.ReadLine());
            switch (switch_on)
            {
                case 1:
                    PerformActionItemMaster itemMaster = new PerformActionItemMaster();
                    itemMaster.ItemMasterPortal();
                    goto repeedAgain;
                case 2:
                    PerformActionCustomer customer = new PerformActionCustomer();
                    customer.portal();
                    goto repeedAgain;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Choise   ");
                    goto repeedAgain;
            }



            Console.ReadKey();
        }
    }
}
