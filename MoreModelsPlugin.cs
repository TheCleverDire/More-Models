using System;
using ClassicalSharp;
using ClassicalSharp.GraphicsAPI;

namespace ClassicalSharp.Model {
namespace MoreModelsPlugin {

	public sealed class Core : Plugin {
		
		public string ClientVersion { get { return "0.99.4"; } }
		
		public void Dispose() { }
		
		public void Init(Game game) {
			game.ModelCache.RegisterTextures("cow.png");
			game.ModelCache.Register("cow", "cow.png", new CowModel(game));
			game.ModelCache.Register("fly", "char.png", new FlyingModel(game));
			game.ModelCache.Register("headless", "char.png", new HeadlessModel(game));
			game.ModelCache.Register("holding", "char.png", new HoldingModel(game));
			game.ModelCache.Register("enderman", "enderman.png", new EndermanModel(game));
			
			// Recreate the modelcache VB to be bigger
			game.Graphics.DeleteVb(ref game.ModelCache.vb);
			game.ModelCache.vertices = new VertexP3fT2fC4b[24 * 20];
			game.ModelCache.vb = game.Graphics.CreateDynamicVb(VertexFormat.P3fT2fC4b,
			                                                   game.ModelCache.vertices.Length);
			game.Server.AppName += " + More Models";
		}
		
		public void Ready(Game game) { }
		
		public void Reset(Game game) { }
		
		public void OnNewMap(Game game) { }
		
		public void OnNewMapLoaded(Game game) { }
	}
  }
}