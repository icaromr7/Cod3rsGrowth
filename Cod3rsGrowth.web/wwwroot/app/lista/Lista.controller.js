sap.ui.define([
	"sap/ui/core/mvc/Controller"
], function (Controller) {
	"use strict";

	return Controller.extend("ui5.anime.app.lista.Lista", {
		onInit(){		
		},
		
		async onBemVindo() {
			this.oDialogo ??= await this.loadFragment({
				name: "ui5.anime.app.BemVindoDialogo"
			});
	
			this.oDialogo.open();
		},
	
		onFecharDialogo(){
			this.byId("bemVindoDialogo").close();
		}
	});

});
