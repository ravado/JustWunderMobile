using System;

namespace JustWunderMobile.Common.DataModels
{
    /// <summary>
    /// Data representation for approved joke
    /// </summary>
    public class ReleaseJokeDataModel : NotifiableBaseDataModel
    {
        private int _id;
        private DateTime _publishDate;
        private string _textJoke;
        private string _userEmail;
        private int _rating;
        private bool _censorship;
        private int _vote;
        private bool _favorite;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value;OnPropertyChanged("PublishDate"); }
        }
        public string TextJoke
        {
            get { return _textJoke; }
            set { _textJoke = value; OnPropertyChanged("TextJoke"); }
        }
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; OnPropertyChanged("UserEmail"); }
        }
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged("Rating"); }
        }
        public bool Censorship
        {
            get { return _censorship; }
            set { _censorship = value; OnPropertyChanged("Censorship"); }
        }
        public int Vote
        {
            get { return _vote; }
            set { _vote = value; OnPropertyChanged("Vote"); }
        }
        public bool Favorite
        {
            get { return _favorite; }
            set { _favorite = value; OnPropertyChanged("Favorite"); }
        }

    }
}