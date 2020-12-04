using System;

namespace adventofcode
{
    class passport
    {
        public int byr { get; set; }
        public int iyr { get; set; }
        public int eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public int cid { get; set; }

        public passport()
        {
            byr = -1;
            iyr = -1;
            eyr = -1;
            hgt = null;
            hcl = null;
            ecl = null;
            pid = null;
            cid = -1;
        }

        public bool isValid()
        {
            bool ret = false;

            
            if(byr != -1 && iyr != -1 && eyr != -1 && hgt != null && hcl != null && ecl != null && pid != null)
            {
                ret = true;
            }
            return ret;
        }

    }
}