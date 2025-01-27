
namespace FKUnitySnippetsLibrary.Interfaces
{
    /// <summary>
    /// An interface to denote that an object can take damage.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// This object takes damage.
        /// </summary>
        void TakeDamage(float damage);
    }
}