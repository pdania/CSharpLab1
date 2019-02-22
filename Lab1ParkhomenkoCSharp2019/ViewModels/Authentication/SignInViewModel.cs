using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab1ParkhomenkoCSharp2019.Tools;
using Lab1ParkhomenkoCSharp2019.Tools.Managers;

namespace Lab1ParkhomenkoCSharp2019.ViewModels.Authentication
{
    internal class SignInViewModel : BaseViewModel
    {
        #region Fields

        private DateTime? _birthDate;

        #region Commands

        private RelayCommand<object> _getDateCommand;
        private string _age;
        private string _westZodiac;
        private string _chineseZodiac;

        #endregion

        #endregion

        #region Properties

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Date
        {
            get { return _birthDate; }
            set => _birthDate = (DateTime) value;
        }

        public string WestZodiac
        {
            get { return _westZodiac; }
            set
            {
                _westZodiac = value; 
                OnPropertyChanged();
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> GetDate
        {
            get
            {
                return _getDateCommand ?? (_getDateCommand = new RelayCommand<object>(
                           DateInplementation, o => CanExecuteCommand()));
            }
        }

        #endregion

        #endregion

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_birthDate.ToString());
        }

        private async void DateInplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => StartWork());
            LoaderManager.Instance.HideLoader();
        }

        internal enum WesternZodiacSign
        {
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }

        internal enum ChineseZodiacSign
        {
            Monkey = 0,
            Rooster,
            Dog,
            Pig,
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Sheep,
        }

        private void StartWork()
        {
            int age = GetAge(Convert.ToDateTime(_birthDate));
            // For loader tester
             Thread.Sleep(2000);
            if (age <= 0 || age > 135)
            {
                MessageBox.Show("Incorrect date value");
                Age = "";
                ChineseZodiac = "";
                WestZodiac = "";
                return;
            }

            Age = "Age: " + age;
            WestZodiac = "West zodiac: " + GetWesternZodiac(Convert.ToDateTime(_birthDate));
            ChineseZodiac = "Chinese zodiac: " + GetChineseZodiacSign(Convert.ToDateTime(_birthDate));
        }

        private int GetAge(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthday.Year;
            if ((currentDate.Month == birthday.Month && currentDate.Day < birthday.Day) ||
                (currentDate.Month < birthday.Month))
                return --age;
            return age;
        }

        private string GetWesternZodiac(DateTime birthday)
        {
            switch (birthday.Month)
            {
                case 1:
                    if (birthday.Day < 20)
                        return WesternZodiacSign.Capricorn.ToString();
                    return WesternZodiacSign.Aquarius.ToString();
                case 2:
                    if (birthday.Day < 19)
                        return WesternZodiacSign.Aquarius.ToString();
                    return WesternZodiacSign.Pisces.ToString();
                case 3:
                    if (birthday.Day < 21)
                        return WesternZodiacSign.Pisces.ToString();
                    return WesternZodiacSign.Aries.ToString();
                case 4:
                    if (birthday.Day < 20)
                        return WesternZodiacSign.Aries.ToString();
                    return WesternZodiacSign.Taurus.ToString();
                case 5:
                    if (birthday.Day < 21)
                        return WesternZodiacSign.Taurus.ToString();
                    return WesternZodiacSign.Gemini.ToString();
                case 6:
                    if (birthday.Day < 22)
                        return WesternZodiacSign.Gemini.ToString();
                    return WesternZodiacSign.Cancer.ToString();
                case 7:
                    if (birthday.Day < 23)
                        return WesternZodiacSign.Cancer.ToString();
                    return WesternZodiacSign.Leo.ToString();
                case 8:
                    if (birthday.Day < 23)
                        return WesternZodiacSign.Leo.ToString();
                    return WesternZodiacSign.Virgo.ToString();
                case 9:
                    if (birthday.Day < 23)
                        return WesternZodiacSign.Virgo.ToString();
                    return WesternZodiacSign.Libra.ToString();
                case 10:
                    if (birthday.Day < 24)
                        return WesternZodiacSign.Libra.ToString();
                    return WesternZodiacSign.Scorpio.ToString();
                case 11:
                    if (birthday.Day < 23)
                        return WesternZodiacSign.Scorpio.ToString();
                    return WesternZodiacSign.Sagittarius.ToString();
                case 12:
                    if (birthday.Day < 22)
                        return WesternZodiacSign.Sagittarius.ToString();
                    return WesternZodiacSign.Capricorn.ToString();
                default:
                    return null;
            }
        }

        private string GetChineseZodiacSign(DateTime birthday)
        {
            return ((ChineseZodiacSign) (birthday.Year % 12)).ToString();
        }

        private bool IsBirthday(DateTime birthday)
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate.Month == birthday.Month && currentDate.Day == birthday.Day)
            {
                return true;
            }

            return false;
        }
    }
}