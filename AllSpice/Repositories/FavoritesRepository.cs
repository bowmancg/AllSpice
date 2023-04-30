namespace AllSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO
            favorites(recipeId, accountId)
            VALUES(@recipeId, @accountId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            favoriteData.CreatedAt = DateTime.Now;
            favoriteData.UpdatedAt = DateTime.Now;
            return favoriteData;
        }

        internal List<Favorite> GetAccountFavorites(string accountId)
        {
            string sql = @"
            SELECT
            fav.*,
            fav.id favoriteId
            FROM favorites fav
            WHERE accountId = @accountId;
            ";
            List<Favorite> favorites = _db.Query<Favorite>(sql, new { accountId }).ToList();
            return favorites;
        }

        internal List<Favorite> GetFavorites()
        {
            string sql = @"
            SELECT
            fav.*,
            fav.id favoriteId
            FROM favorites fav
            ";
            List<Favorite> favorites = _db.Query<Favorite>(sql).ToList();
            return favorites;
        }

    internal void Remove(int id)
    {
        string sql = @"
        DELETE FROM favorites WHERE Id = @Id;
        ";
        _db.Execute(sql, new { id });
    }
    }

}