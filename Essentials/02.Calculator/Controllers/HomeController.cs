using _02.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? quantity, string type, string unit)
        {
            var result = new List<Measure>();
            if (quantity != null)
            {
                double? selectedValue = CalculateSelectedValue(type, unit);

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        var measure = new Measure();
                        measure.BitBite = (BitByte)j;
                        measure.Thousand = (Thousand)i;
                        measure.Kilo = int.Parse(unit);
                        measure.Quantity = quantity;
                        measure.InBits = selectedValue;
                        result.Add(measure);
                    }
                }
            }

            //ViewBag.Result = result;
            return View(result);
        }

        public double? CalculateSelectedValue(string type, string unit)
        {
            double? selectedValue = 0;
            if (type.ToLower().Contains("bit"))
            {
                selectedValue = 1;
                type = type.Substring(0, type.Length - 3);
            }
            else
            {
                selectedValue = 8;
                type = type.Substring(0, type.Length - 4);
            }

            double unitDouble = double.Parse(unit);

            switch (type)
            {
                case "Kilo":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Kilo);
                    break;
                case "Mega":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Mega);
                    break;
                case "Giga":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Giga);
                    break;
                case "Tera":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Tera);
                    break;
                case "Peta":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Peta);
                    break;
                case "Exa":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Exa);
                    break;
                case "Zetta":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Zetta);
                    break;
                case "Yotta":
                    selectedValue *= Math.Pow(unitDouble, (int)Thousand.Yotta);
                    break;
                default:
                    break;
            }

            return selectedValue;
        }
    }
}