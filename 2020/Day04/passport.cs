using System;
using System.Text.RegularExpressions;

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
                if(byr < 1920 || byr > 2002)
                {
                    return false;
                }

                if(iyr < 2010 || iyr > 2020)
                {
                    return false;
                }

                if(eyr < 2020 || eyr > 2030)
                {
                    return false;
                }

                if(hgt.Contains("in"))
                {
                    if (Convert.ToInt32(hgt.Replace("in", "")) < 59 || Convert.ToInt32(hgt.Replace("in", "")) > 76)
                    {
                        return false;
                    }
                }
                else if(hgt.Contains("cm"))
                {
                    if (Convert.ToInt32(hgt.Replace("cm", "")) < 150 || Convert.ToInt32(hgt.Replace("cm", "")) > 193)
                    {
                        return false;
                    }
                }

                Regex regexHcl = new Regex(@"[#]{1}[0-9a-f]{6}");
                if(!regexHcl.IsMatch(hcl))
                {
                    return false;
                }

                if (ecl != "amb" && ecl != "blu" && ecl != "brn" && ecl != "gry" && ecl != "grn" && ecl != "hzl" && ecl != "oth")
                {
                    return false;
                }

                if (pid.Length != 9)
                {
                    return false;
                }

                ret = true;
            }
            return ret;
        }

    }
}