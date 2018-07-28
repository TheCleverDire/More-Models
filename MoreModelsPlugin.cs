using ClassicalSharp;
using ClassicalSharp.GraphicsAPI;
using ClassicalSharp.Model;

namespace MoreModels
{
	public sealed class Core : Plugin {
		
		public string ClientVersion { get { return "0.99.4"; } }
		
		public void Dispose() { }
		
		public void Init(Game game)
        {
            game.ModelCache.RegisterTextures("car.png");
            game.ModelCache.RegisterTextures("cow.png");
            game.ModelCache.RegisterTextures("croc.png");
            game.ModelCache.RegisterTextures("printer.png");

            game.ModelCache.Register("car", "car.png", new CarModel(game));
			game.ModelCache.Register("cow", "cow.png", new CowModel(game));
            game.ModelCache.Register("croc", "croc.png", new CrocModel(game));
			game.ModelCache.Register("flying", "char.png", new FlyingModel(game));
			game.ModelCache.Register("headless", "char.png", new HeadlessModel(game));
			game.ModelCache.Register("holding", "char.png", new HoldingModel(game));
            game.ModelCache.Register("male", "char.png", new MaleModel(game));
            game.ModelCache.Register("printer", "printer.png", new PrinterModel(game));
			
			// Recreate the modelcache VB to be bigger
			game.Graphics.DeleteVb(ref game.ModelCache.vb);
			game.ModelCache.vertices = new VertexP3fT2fC4b[24 * 20];
			game.ModelCache.vb = game.Graphics.CreateDynamicVb(VertexFormat.P3fT2fC4b, game.ModelCache.vertices.Length);
			game.Server.AppName += " + Models 0.2";
		}
		
		public void Ready(Game game) { }
		
		public void Reset(Game game) { }
		
		public void OnNewMap(Game game)
        {
            //Increase holding model size limit if inf id is supported
            IModel model = (HoldingModel)game.ModelCache.Get("holding");
            if(model is HoldingModel)
            {
                HoldingModel holding = (HoldingModel)model;
                holding.resetMaxScale();
            }
        }
		
		public void OnNewMapLoaded(Game game) { }
	}
}