namespace AllSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

        internal List<Favorite> GetAccountFavorites(string accountId)
        {
            List<Favorite> favorites = _repo.GetAccountFavorites(accountId);
            return favorites;
        }

        internal List<Favorite> GetFavorites()
        {
            List<Favorite> favorites = _repo.GetFavorites();
            return favorites;
        }

        internal string RemoveFavorite(int favoriteId)
        {
            _repo.Remove(favoriteId);
            return "Favorite deleted.";
        }
    }
}