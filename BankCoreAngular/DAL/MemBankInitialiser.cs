using MemBankCoreAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBankCoreAngular.DAL
{
    public class MemBankInitialiser
    {
        public static void Initialize(MemBankContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Languages.
            if (context.Language.Any())
            {
                return;   // DB has been seeded
            }


            // Language
            var Languages = new Language[]
            {
                new Language{Name="C#"},
                new Language{Name="Javascript"},
            };
            foreach (Language l in Languages)
            {
                context.Language.Add(l);
            }
            context.SaveChanges();


            // Project
            var Projects = new Project[]
{
                new Project{Name="Synergy 5"},
                new Project{Name="OB10"},
};
            foreach (Project p in Projects)
            {
                context.Project.Add(p);
            }
            context.SaveChanges();

            var ProjectSynergy = Projects[0];
            var ProjectOB10 = Projects[1];


            // Module
            var Modules = new Module[]
{
                new Module{Name="Work breakdown", ProjectId = ProjectSynergy.Id},
                new Module{Name="Portal", ProjectId = ProjectSynergy.Id},
                new Module{Name="Intranet", ProjectId = ProjectOB10.Id},
};
            foreach (Module m in Modules)
            {
                context.Module.Add(m);
            }
            context.SaveChanges();


            // Code Item
            var CodeItems = new CodeItem[]
{
                new CodeItem{Title="one", Text="code item one", ProjectId = ProjectSynergy.Id},
                new CodeItem{Title="two", Text="code item two", ProjectId = ProjectSynergy.Id},
                new CodeItem{Title="three", Text="code item three", ProjectId = ProjectSynergy.Id},
                new CodeItem{Title="four", Text="code item four", ProjectId = ProjectSynergy.Id},
                new CodeItem{Title="five", Text="code item five", ProjectId = ProjectSynergy.Id},
};
            foreach (CodeItem ci in CodeItems)
            {
                context.CodeItem.Add(ci);
            }
            context.SaveChanges();

            var codeItemOne = CodeItems[0];
            var codeItemTwo = CodeItems[1];
            var codeItemThree = CodeItems[2];
            var codeItemFour = CodeItems[3];
            var codeItemFive = CodeItems[4];


            // Tag
            var Tags = new Tag[]
{
                new Tag{Text="WBD", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemOne.Id},
                new Tag{Text="WBD", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemTwo.Id},
                new Tag{Text="for loop", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemOne.Id},
                new Tag{Text="iteration", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemOne.Id},
                new Tag{Text="iteration", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemTwo.Id},
                new Tag{Text="iteration", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemThree.Id},
                new Tag{Text="iteration", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemFour.Id},
                new Tag{Text="exception", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemTwo.Id},
                new Tag{Text="error handling", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemTwo.Id},
                new Tag{Text="error handling", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemFour.Id},
                new Tag{Text="error handling", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemFive.Id},
                new Tag{Text="extensions", ParentTypeId = Global.Constants.Tag.ParentType.CodeItem, ParentId = codeItemTwo.Id},
};
            foreach (Tag t in Tags)
            {
                context.Tag.Add(t);
            }
            context.SaveChanges();

        }


    }
}
