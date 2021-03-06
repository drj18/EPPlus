/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Text
{
    internal class Mid : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 3);
            var text = ArgToString(arguments, 0);
            var startIx = ArgToInt(arguments, 1);
            var length = ArgToInt(arguments, 2);
            if(startIx<=0)
            {
                throw(new ArgumentException("Argument start can't be less than 1"));
            }
            //Allow overflowing start and length
            if (startIx > text.Length)
            {
                return CreateResult("", DataType.String);
            }
            else
            {
                var result = text.Substring(startIx - 1, startIx - 1 + length < text.Length ? length : text.Length - startIx + 1);
                return CreateResult(result, DataType.String);
            }
        }
    }
}
