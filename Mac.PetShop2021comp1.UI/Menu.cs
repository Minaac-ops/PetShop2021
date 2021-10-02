using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mac.PetShop2021comp.Domain.Services;
using Mac.PetShop2021comp1.Core.IServices;
using Mac.PetShop2021comp1.Core.Models;

namespace Mac.PetShop2021comp1.UI
{
    public class Menu
    {
        private IPetTypeService _petTypeService;
        private IPetService _service;
        private static int petId = 1;
        private static int typeId = 1;
        
        public Menu(IPetService service, IPetTypeService petTypeService)
        {
            _service = service;
            _petTypeService = petTypeService;
        }

        public void Start()
        {
            ShowWelcomeGreeting();
            //StartLoop();
        }

        private void ShowWelcomeGreeting()
        {
            Print(StringConstants.WelcomeGreeting);
        }

        /*private void StartLoop()
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
                        RemovePet();
                        break;
                    case 5:
                        SearchByType();
                        break;
                    case 6:
                        Get5Cheapest();
                        break;
                }
            }
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
            Print(StringConstants.SelectOptions);
            string[] menuItems =
            {
                StringConstants.MenuTextCreateNewPet,
                StringConstants.MenuTextReadPets,
                StringConstants.MenuTextUpdatePet,
                StringConstants.MenuTextDeletePet,
                StringConstants.MenuTextSearchByType,
                StringConstants.MenuTextCheapest
            };
            
            for (int i = 0; i < menuItems.Length; i++)
            {
                Print($"{(i+1)}: {menuItems[i]}");
            }
        }
        
        /*private void CreatePet()
        {
            Print(StringConstants.CreatePetGreeting);
            
            //Pet Type
            Print(StringConstants.PetTypeName);
            ReadAllTypes();
            int typeId = int.Parse(Console.ReadLine());
            PetType petType = _petTypeService.GetById(typeId);

            //Actual pet
            Print(StringConstants.PetNameText);
            var petName = Console.ReadLine();
            
            Print(StringConstants.PetBirtdayText);
            DateTime petBirthday = DateTime.Parse(Console.ReadLine());
            
            Print(StringConstants.PetSoldTimeText);
            DateTime petSoldTime = DateTime.Parse(Console.ReadLine());
            
            Print(StringConstants.PetColorText);
            var petColor = Console.ReadLine();
            
            Print(StringConstants.PetPriceText);
            double petPrice = Double.Parse(Console.ReadLine());

            var pet = new Pet()
            {
                Birthday = petBirthday,
                Color = petColor,
                Name = petName,
                Type = petType,
                SoldTime = petSoldTime,
                Price = petPrice
            };
            pet = _service.Add(pet);
            Print($"Pet created.\nId: {pet.Id}, pet type: {pet.Type}," +
                  $" name: {pet.Name}, color: {pet.Color}, birthday: {pet.Birthday} sold time: {pet.SoldTime}, price: {pet.Price}/n");
        }
        
        /*private void ReadAllPets()
        {
            foreach (var pet in _service.GetPets())
            {
                Print($"Pet type: {pet.Type.Name}, name: {pet.Name}, birthday: {pet.Birthday}, color: {pet.Color}, price: {pet.Price}, sold: {pet.SoldTime}, id: {pet.Id}");
            }
        }

        private void ReadAllTypes()
        {
            foreach (var type in _petTypeService.GetPetTypes())
            {
                Print($"Id: {type.Id}, type: {type.Name}");
            }
        }

        private void Get5Cheapest()
        {
            Print(StringConstants.CheapestPetsMessage);
            foreach (var pet in _service.Get5Cheapest())
            {
                Print($"price: {pet.Price}, name: {pet.Name}, birthday: {pet.Birthday}, color: {pet.Color}, sold: {pet.SoldTime}, id: {pet.Id}");
            }
        }

        private void SearchByType()
        {
            Print(StringConstants.TypeTypeMessage);
            var typeSearch = Console.ReadLine();

            foreach (var pet in _service.SearchByType(typeSearch))
            {
                Print($"name: {pet.Name}, birthday: {pet.Birthday}, color: {pet.Color}, price: {pet.Price}, sold: {pet.SoldTime}, id: {pet.Id}");
            }
        }*/
        
        private void UpdatePet()
        {
            Print(StringConstants.TypeIdOfPetMessage);
            int idUpdate = int.Parse(Console.ReadLine());
            var petUpdate = _service.SearchById(idUpdate);
            
            Print(StringConstants.NewNameMessage);
            var newName = Console.ReadLine();
            
            Print(StringConstants.NewPriceMessage);
            double newPrice = double.Parse(Console.ReadLine());

            _service.UpdatePet(new Pet()
            {
                Id = petUpdate.Id,
                Name = newName,
                Price = newPrice,
                Birthday = petUpdate.Birthday,
                Colors = petUpdate.Colors,
                SoldTime = petUpdate.SoldTime,
                Type = petUpdate.Type
            });
            Print($"Pet with if {petUpdate.Name} was succesfully updated. New name: {petUpdate.Name}, new Price = {petUpdate.Price}.");
        }

        private void RemovePet()
        {
            Print(StringConstants.TypeIdOfPetMessage);
            var idDelete = int.Parse(Console.ReadLine());
            if (idDelete != null)
            {
                _service.RemovePet(idDelete);
                Print($"Pet with id {idDelete} was successfully removed from list of pets.");
            }
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
        
        /*public void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Lassie",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Dog"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "Brown",
                Price = 4000
            };
            _service.Add(pet1);
            
            var pet2 = new Pet()
            {
                Name = "Trine",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Rabbit"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "Black",
                Price = 5000
            };
            _service.Add(pet2);
            
            var pet3 = new Pet()
            {
                Name = "Mathias",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Fox"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "Red",
                Price = 6000
            };
            _service.Add(pet3);
            
            var pet4 = new Pet()
            {
                Name = "Rex",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Horse"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "Black",
                Price = 30000
            };
            _service.Add(pet4);
            
            var pet5 = new Pet()
            {
                Name = "Goat",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Goat"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "White",
                Price = 500
            };
            _service.Add(pet5);
            
            var pet6 = new Pet()
            {
                Name = "Jump",
                Type = _petTypeService.CreatePetType(new PetType()
                {
                    Name = "Rabbit"
                }),
                Birthday = new DateTime(2021, 5, 8),
                SoldTime = new DateTime(2021, 5, 9),
                Colors = "Brown",
                Price = 150
            };
            _service.Add(pet6);
        }*/
    }
}