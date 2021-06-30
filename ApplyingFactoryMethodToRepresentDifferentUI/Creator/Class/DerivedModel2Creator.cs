using ApplyingFactoryMethodToRepresentDifferentUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplyingFactoryMethodToRepresentDifferentUI.Creator.Class
{
    public class DerivedModel2Creator : Creator.Intrface.IModelCreator
    {
       

        public IActionResult Create()
        {
            PartialViewResult viewResult = new PartialViewResult();
            viewResult.ViewName = "DerivedModel2";
            
            return  viewResult;
        }
    }
    
}
