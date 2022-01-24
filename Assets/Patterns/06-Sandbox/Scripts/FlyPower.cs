namespace SandboxPattern 
{
    public class FlyPower : SuperPower
    {
        public override void Active()
        {
            Move("Up");
            SpawnParticle("Smoke");
            PlaySound("Jump");
        }
    }

}

