using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invoicing_T
{
    public class GVPEntity
    {
        private SortedList<string, GetValuePurchases> pur_sl = new SortedList<string, GetValuePurchases>();

        public GVPEntity()
        {

        }

        public void Add(GetValuePurchases gvp)
        {
            this.pur_sl.Add(gvp.PurID, gvp);
        }
        public void Edit(GetValuePurchases gvp)
        {
            if (this.pur_sl.ContainsKey(gvp.PurID))
            {
                this.pur_sl[gvp.PurID] = gvp;
            }
        }
        public void Delete(GetValuePurchases gvp)
        {
            this.pur_sl.Remove(gvp.PurID);
        }

        public virtual IList<GetValuePurchases> GetValuePurchasesDatas
        {
            get
            {
                return this.pur_sl.Values;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.pur_sl.Values.GetEnumerator();
        }

    }
}