#region Licencia
/*
   Copyright 2013 Juan Diego Martinez

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Common.Collections
{
    public static class CollectionExtensionHelper
    {
        // http://www.dotnetperls.com/fisher-yates-shuffle
        public static T[] Shuffle<T>(this T[] array)
        {
            var random = new Random();

            for (int i = array.Length; i > 1 i--)
            {
                // Obtenemos el elemento a cambiar
                int j = random.Next(i); // 0 <= j <= i - 1

                // Cambiamos
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }

            return array;
        }
    }
}
