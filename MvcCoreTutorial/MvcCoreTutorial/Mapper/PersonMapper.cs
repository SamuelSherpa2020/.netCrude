using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcCoreTutorial.Models.Domain;
using MvcCoreTutorial.ViewModels;

namespace MvcCoreTutorial.Mapper;

public static class PersonMapper
{

    public static Person ToModel(this PersonViewModel PersonVM)
    {
        return new Person
        {
            Id = PersonVM.Id,
            Name = PersonVM.Name,
            Age = PersonVM.Age,
            Email = PersonVM.Email,

        };
    }
    public static PersonViewModel ToViewModel(this Person person)
    {
        return new PersonViewModel
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
            Email = person.Email
        };
    }

    public static List<PersonViewModel> ToViewModel(this List<Person> person)
    {
        return person.Select(student => student.ToViewModel()).ToList();
    }

}

