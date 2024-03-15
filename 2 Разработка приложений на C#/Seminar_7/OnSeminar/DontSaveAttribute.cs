using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DontSaveAttribute : Attribute
    {

        /*Реализуйте атрибут работающий совместно с предыдущим методом сохранения в строку.
         * Помеченное этим атрибутом свойство не должно подлежать сохранению(пропускается). 
         * Для проверки пометить атрибутом любой свойство класса и убедитесь что оно не сохраняется.*/


    }
}
