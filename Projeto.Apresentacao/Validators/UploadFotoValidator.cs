using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Projeto.Apresentacao.Validators
{
    public class UploadFotoValidator : ValidationAttribute
    {
     
        public override bool IsValid(object value)
        {
            
            if (value != null)
            {
                if (value is HttpPostedFileBase)
                {


                    HttpPostedFileBase upload = (HttpPostedFileBase)value;

                    return (upload.FileName.EndsWith(".jpg") && (upload.ContentLength <= 50000)); //até 50Kb
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}