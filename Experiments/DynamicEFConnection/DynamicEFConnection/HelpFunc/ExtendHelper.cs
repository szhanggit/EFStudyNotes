using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicEFConnection.HelpFunc
{
    public static class ExtendHelper
    {
        //https://stackoverflow.com/questions/3445784/copy-the-property-values-to-another-object-with-c-sharp/28814556
        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    { // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }

            }

        }

        public static void ConvertList<T, TU>(this List<T> slist, List<TU> dlist)
        {
            if (slist != null && dlist != null && slist.Count > 0)
            {
                foreach (var s in slist)
                {
                    TU obj = (TU)Activator.CreateInstance(typeof(TU));
                    s.CopyPropertiesTo<T, TU>(obj);
                    if (obj != null)
                    {
                        dlist.Add(obj);
                    }
                }
            }
        }
    }
}
