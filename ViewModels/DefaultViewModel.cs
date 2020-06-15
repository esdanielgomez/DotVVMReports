using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.BL.Services;
using AppDemo.BL.Models;
using DotVVM.Framework.Controls;

namespace AppDemo.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly PersonService personService;
        public GridViewDataSet<PersonModel> Persons { get; set; } = new GridViewDataSet<PersonModel>();
        public List<int> PersonTypes { get; set; } = new List<int>();
        public string IdSearch { get; set; }
        public bool SearchByTextVisible { get; set; } = false;

        public DefaultViewModel(PersonService personService)
        {
            this.personService = personService;
        }

        public override async Task PreRender(){}

        public async Task UpdatePersonList()
        {
            IdSearch = null;

            if (PersonTypes.Count == 2)
            {
                Persons.Items = await personService.GetAllPersonsAsync();
                SearchByTextVisible = true;
            }
            else if (PersonTypes.Count == 1)
            {
                int IdPersonType = PersonTypes.FirstOrDefault();
                Persons.Items = await personService.GetAllPersonsByTypeAsync(IdPersonType);
                SearchByTextVisible = true;
            }
            else
            {
                Persons.Items.Clear();
                SearchByTextVisible = false;
            }
        }

        public async Task SearchById()
        {
            if (PersonTypes.Count == 2)
            {
                if (!string.IsNullOrEmpty(IdSearch))
                {
                    List<PersonModel> list = new List<PersonModel>(); ;
                    list.Add(await personService.GetPersonByIdAsync(Int32.Parse(IdSearch)));
                    Persons.Items = list;
                }
                else {
                    Persons.Items = await personService.GetAllPersonsAsync();
                }
            }
            else if (PersonTypes.Count == 1)
            {
                if (!string.IsNullOrEmpty(IdSearch))
                {
                    int IdPersonType = PersonTypes.FirstOrDefault();
                    List<PersonModel> list = new List<PersonModel>(); ;
                    list.Add(await personService.GetPersonByIdAndTypeAsync(Int32.Parse(IdSearch), IdPersonType));
                    Persons.Items = list;
                }
                else
                {
                    int IdPersonType = PersonTypes.FirstOrDefault();
                    Persons.Items = await personService.GetAllPersonsByTypeAsync(IdPersonType);
                }
            }
        }
    }
}
