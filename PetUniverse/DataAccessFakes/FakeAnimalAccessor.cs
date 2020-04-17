﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Chuck Baxter
    /// Created: 2/6/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Daulton Schilling, 2/7/2020
    /// 
    /// The fake animal accessor class, uses a collection of animal objects instead of an actual database
    /// </summary>
    public class FakeAnimalAccessor : IAnimalAccessor
    {
        private List<Animal> animals;
        private List<Animal> activeAnimals;
        private List<string> species;

        private List<AnimalNames> names;

        private Animal _animal;
        private List<Animal> animalProfiles;

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// the List of animals to use in tests instead of an actual database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public FakeAnimalAccessor()
        {
            animals = new List<Animal>()
            {
                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "A",
                    ArrivalDate = DateTime.Now.Date,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "A",
                },

                new Animal()
                {
                    AnimalID = 2,
                    AnimalName = "B",
                    Dob = DateTime.Now.Date,
                    AnimalBreed = "B",
                    ArrivalDate = DateTime.Now.Date,
                    CurrentlyHoused = true,
                    Adoptable = true,
                    Active = true,
                    AnimalSpeciesID = "B",
                }
            };

            animalProfiles = new List<Animal>()
            {
                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    ProfileImage = "sample images",
                    ProfileDescription = "sample description"
                },

                new Animal()
                {
                    AnimalID = 1,
                    AnimalName = "A",
                    ProfileImage = "sample images",
                    ProfileDescription = "sample description"
                }
            };
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/6/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Daulton Schilling, 2/7/2020
        /// 
        /// The fake data access method for adding a new animal
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="animal"></param>
        /// <returns></returns>
        public int InsertAnimal(Animal animal)
        {
            try
            {
                animals.Add(animal);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/13/2020
        /// Approver: Austin Gee
        /// The fake data access method for selecting all of the animal profiles
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <returns>The default list of animal profiles</returns>
        public List<Animal> SelectAllAnimnalProfiles()
        {
            return animalProfiles;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/13/2020
        /// Approver: Carl Davis, 2/14/2020
        /// Approver: Daulton Schilling, 2/14/2020
        /// 
        /// The fake data access method for selecting all of the active animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByActive(bool active = true)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/19/2020
        /// Approver: Zach Behrensmeyer
        /// Approver: 
        /// 
        /// The fake data access method for selecting all of the inactive animals
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<Animal> SelectAnimalsByInactive(bool active = false)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (!animal.Active)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                // should be null if there is a failure
                activeAnimals = null;
                return activeAnimals;
            }
        }

        /// <summary>
        /// Creator: Michael Thompson
        /// Created: 2/19/2020
        /// Approver: Austin Gee
        /// 
        /// The fake data access method for updating the animal propfile and descriptiopn
        /// in the database
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// <param name="animal"></param>
        /// <param name="profileDescription"></param>
        /// <param name="profileImagePath"></param>
        /// <returns></returns>
        public bool UpdateAnimalProfile(int animalID, string profileDescription, string profileImagePath)
        {
            _animal = new Animal()
            {
                AnimalID = 100000,
                ProfileDescription = "This is a fake Pet profile description",
                ProfileImage = "/images",
            };
            return true;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 2/28/2020
        /// Approver: Jordan Lindo, 2/28/2020
        /// Approver: 
        /// 
        /// Fake data access that returns a list of strings for animal species
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of strings></returns>
        public List<string> SelectAnimalSpeciesID()
        {
            species = new List<string>{
                "Dog",
                "Cat"
            };
            return species;
        }

        /// <summary>
        /// Creator: Chuck Baxter
        /// Created: 3/12/2020
        /// Approver: Austin Gee, 3/12/2020
        /// 
        /// Fake data access that returns 1 if the ids match, otherwise returns 0
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="oldAnimal"></param>
        /// <param name="newAnimal"></param>
        /// <returns></returns>
        public int UpdateAnimal(Animal oldAnimal, Animal newAnimal)
        {
            foreach (Animal animal in animals)
            {
                if (animal.AnimalID == oldAnimal.AnimalID)
                {
                    return 1;
                }
            }
            return 0;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver:
        /// </remarks>
        /// <param name="AnimalID">Primary key that identifies the animal</param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateAdoptable(int animalID)
        {
            int animalIndex = animals.FindIndex(a => a.AnimalID == animalID);

            Animal animal = animals[animalIndex];

            animal.Adoptable = true;

            animals[animalIndex] = animal;

            return (from a in animals
                    where a.AnimalID == animalID && a.Adoptable == true
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateAnimal(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int ActivateCurrentlyHoused(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateAdoptable(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateAnimal(int animalID)
        {


            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 2/5/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Dummy method that returns the result as if the real method had succeded.
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/7/2020
        /// Update: Reimplemented method after bugfixes
        /// Approver: Carl Davis, 3/13/2020
        /// </remarks>
        /// <param name="AnimalID"> Primary key that identifies the animal </param>
        /// <returns>The number of animals that match the supplied primary key. Should either be 0 (fail) or 1 (success)</returns>
        public int DeactivateCurrentlyHoused(int animalID)
        {
            return (from a in animals
                    where a.AnimalID == animalID
                    select a).Count();
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Fake data access that returns a list of animal names
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of animal names></returns>
        public List<AnimalNames> GetNames()
        {
            try
            {
                names = new List<AnimalNames>();
                foreach (AnimalNames name_ in names)
                {
                    names.Add(name_);
                }
                return names;
            }
            catch
            {

                names = null;
                return names;
            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 4/13/2020
        /// Approver: Carl Davis 4/16/2020
        /// Approver: 
        /// 
        /// Fake data access that returns an animal by its ID
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param ></param>
        /// <returns>List of animal attributes></returns>
        public List<Animal> GetAnimalByAnimalID(int ID)
        {
            try
            {
                activeAnimals = new List<Animal>();
                foreach (Animal animal in animals)
                {
                    if (animal.AnimalID == ID)
                    {
                        activeAnimals.Add(animal);
                    }
                }
                return activeAnimals;
            }
            catch
            {
                activeAnimals = null;
                return activeAnimals;
            }
        }
    }
}
