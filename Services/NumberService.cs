namespace NumbertTestTask.Services
{
    public class NumberService
    {
        public async Task<string> getNumberStringByValue(decimal number)
        {
            if (number == 0)
            {
                return "զրո";
            }
            if (number < 0)
            {
                return "մինուս " + await getNumberStringByValue(Math.Abs(number));
            }
            var unitsMap = new[] { "զրո", "մեկ", "երկու", "երեք", "չորս", "հինգ", "վեց", "յոթ", "ութ", "ինը",
                "տաս", "տասնմեկ", "տասներկու", "տասներեք", "տասնչորս", "տասնհինգ", "տասնվեց", "տասնյոթ", "տասնութ", "տասնինը" };
            var tensMap = new[] { "զրո", "տաս", "քսան", "երեսուն", "քառասուն", "հիսուն", "վաթսուն", "յոթանասուն", "ութանասուն", "իննսուն" };
            string res = string.Empty;

            if (Math.Floor(number / 1000000000) > 0)
            {
                if (Convert.ToInt32(Math.Floor(number / 1000000000)) == 1)
                {
                    res = $"{res} միլիոն";
                }
                else
                {
                    res = $"{res} {await getNumberStringByValue(Convert.ToInt32(Math.Floor(number / 1000000000)))} միլիարդ";
                }
                number %= 1000000000;
            }
            if (Math.Floor(number / 1000000) > 0)
            {
                if (Convert.ToInt32(Math.Floor(number / 1000000)) == 1)
                {
                    res = $"{res} միլիոն";
                }
                else
                {
                    res = $"{res} {await getNumberStringByValue(Convert.ToInt32(Math.Floor(number / 1000000)))} միլիոն";
                }
                number %= 1000000;
            }

            if (Math.Floor(number / 1000) > 0)
            {
                if (Convert.ToInt32(Math.Floor(number / 1000)) == 1)
                {
                    res = $"{res} հազար";
                }
                else
                {
                    res = $"{res} {await getNumberStringByValue(Convert.ToInt32(Math.Floor(number / 1000)))} հազար";
                }
                number %= 1000;
            }

            if (Math.Floor(number / 100) > 0)
            {
                if (Convert.ToInt32(Math.Floor(number / 100)) == 1)
                {
                    res = $"{res} հարյուր";
                }
                else
                {
                    res = $"{res} {unitsMap[Convert.ToInt32(Math.Floor(number / 100))]} հարյուր";
                }
                number %= 100;
            }

            if (Math.Floor(number / 10) > 0)
            {
                if (Convert.ToInt32(Math.Floor(number / 10)) == 1)
                {
                    number %= 10;
                    res = $"{res} {unitsMap[Convert.ToInt32(Math.Floor(number) + 10)]}";
                    number %= 1;
                }
                else
                {
                    res = $"{res} {tensMap[Convert.ToInt32(Math.Floor(number / 10))]}";
                    number %= 10;
                }
            }

            if (Math.Floor(number) > 0)
            {
                res = $"{res} {unitsMap[Convert.ToInt32(Math.Floor(number))]}";
                number %= 1;
            }

            string numString = number.ToString();
            int length = 0;
            if (numString.IndexOf(".") != -1)
            {
                length = numString.Substring(numString.IndexOf(".") + 1).Length;
                numString = numString.Substring(numString.IndexOf(".") + 1);
            }

            if (length > 0)
            {
                if (string.IsNullOrEmpty(res))
                {
                    res = "զրո";
                }
                number = Convert.ToDecimal(numString);
                if (number > 0)
                {
                    res = $"{res} ամբողջ";
                    res = $"{res} {await getNumberStringByValue(number)}";
                    switch (length)
                    {
                        case 1:
                            res = $"{res} տասնորդական";
                            break;
                        case 2:
                            res = $"{res} հարյուրերորդական”";
                            break;
                        default:
                            break;
                    }
                }
            }


            return res;
        }
    }
}
