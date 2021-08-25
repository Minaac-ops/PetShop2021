using System;
using System.Runtime.InteropServices;
using Mac.PetShop2021comp1.Core.IServices;

namespace Mac.PetShop2021comp1.UI
{
    public class Menu
    {
        private IPetService _service;
        private static int id = 1;
        
        public Menu(IPetService service)
        {
            _service = service;
        }

        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }

        private void ShowWelcomeGreeting()
        {
            Print(StringConstants.WelcomeGreeting);
        }
        
        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        CreatePet();
                        break;
                    case 2:
                        ReadAllPets();
                        break;
                    case 3:
                        UpdatePet();
                        break;
                    case 4:
                        DepetePet();
                        break;
                    case 5:
                        SearchByType();
                        break;
                }
            }
        }

        private void SearchByType()
        {
            throw new NotImplementedException();
        }

        private void DepetePet()
        {
            throw new NotImplementedException();
        }

        private void UpdatePet()
        {
            throw new NotImplementedException();
        }

        private void ReadAllPets()
        {
            throw new NotImplementedException();
        }

        private void CreatePet()
        {
            throw new NotImplementedException();
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Print("\n");
            Print(StringConstants.SelectOptions);
            Print("\n");
            string[] menuItems =
            {
                StringConstants.MenuTextCreateNewPet,
                StringConstants.MenuTextReadPets,
                StringConstants.MenuTextUpdatePet,
                StringConstants.MenuTextDeletePet,
                StringConstants.MenuTextSearchByType
            };
            
            for (int i = 0; i < menuItems.Length; i++)
            {
                Print($"{(i+1)}: {menuItems[i]}");
            }
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
}