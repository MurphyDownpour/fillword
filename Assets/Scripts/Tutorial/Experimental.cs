using System;
using UnityEngine;

namespace DefaultNamespace
{
    
    
    public class Experimental : MonoBehaviour
    {
        private void Awake()
        {
            var testClass = new TEST();
            testClass.Main();
        }
    }
    
    public class Cell
    {
        
    }
    
    public class CellMB : MonoBehaviour
    {
        
    }
    
    
    public enum Type
    {
        BlackCoffee,
        Americano,
        Espresso
    }
    
    public abstract class Coffee : IReward
    {
        public float Reward { get; set; }
        
        public Type Type;

        public virtual void A()
        {
            B();
        }

        public abstract void B();

        public void C()
        {
            //
        }
        
        public Coffee(Type type)
        {
            
        }
    
        protected void DisposeCoffee()
        {
            
        }
    }
    
    public class Latte : Coffee
    {
        private float _volume;
        public float Volume => _volume;

        public new void C()
        {
            
        }

        public override void B()
        {
            
        }

        public override void A()
        {
            base.A();
        }

        public Latte(Type type, float volume, float customReward) : base(type)
        {
            _volume = volume;
            base.DisposeCoffee();
            Reward = customReward;
            A();
            B();
        }

 
    }
    
    public class TEST
    {
        public void Main()
        {
           // var coffee = new Coffee(Type.Espresso);
            var latte = new Latte(Type.Americano, 11f, 100);
           // var coffee2 = new Coffee(Type.Espresso);
           // coffee = coffee2;
           // coffee2.Type = Type.BlackCoffee;
            PrintDrunkCoffeeType(latte);
        }
    
        public void PrintDrunkCoffeeType(Coffee coffee)
        {
            if (coffee is Latte latte)
            {
                Debug.Log($"Latte was drunk: {coffee.Type}. volume: {latte.Volume}");
            }

            // Collider col = null;
            // var damageable = col.gameObject.GetComponent<IDamageable>();
            // if (damageable != null)
            // {
            //     damageable.ApplyDamage(20f);
            // }
            if (coffee is IReward reward)
            {
                var rew = reward.Reward;
                var l = reward as Latte;
            }
        }
    }

    public interface IDamageable
    {
        void ApplyDamage(float damage);
    }

    public interface IReward
    {
        float Reward { get; set; }
    }
}