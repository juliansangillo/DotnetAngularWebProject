namespace DotnetAngularWebProject.Common {
    public abstract class Entity : IEntity {
        public Entity(int id) => Id = id;

        public int Id { get; }

        /*
         * Uncomment the following code if you have need for equality and/or 
         * string formatting in your entities.
         * 
        public bool Equals(Entity other) => Id == other.Id;

        public override bool Equals(object? obj)
            => obj is not null
                && (ReferenceEquals(this, obj)
                    || Equals((Entity)obj));

        public override int GetHashCode() => Id.GetHashCode();

        public override string? ToString() => $"{GetType().FullName} [ {Id} ]";
        */
    }
}
