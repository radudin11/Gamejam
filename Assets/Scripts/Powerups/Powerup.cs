
namespace Game {
    public class Powerup: MonoBehaviour {
        public enum Type {
            Common, Rare, Epic, Legendary
        } type;

        public abstract void Use();
    };
}