using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace News.behavious
{
   public class EmailValidateBehaviour : Behavior<Entry>
    {
        const string emailRegex = @"^[_A-Za-z0-9-]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$";

        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);

            entry.TextChanged += Entry_TextChanged;

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            base.OnDetachingFrom(entry);

            entry.TextChanged -= Entry_TextChanged;
        }
    }
}
