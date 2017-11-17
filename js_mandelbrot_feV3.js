var iF1, iF2, iF3; //Variables permettant de définir la zone à dessiner.
var canvas_ColorMap; //Canvas où est dessinée la Color Map.
var canvas_Fractal; //Canvas où est dessinée la fractale.
var PI;
var maxIter;
var pressed = false;//Permet de savoir si on a pressé la souris pour définir la zone à zoomer.
//On crée le canvas (on ne le fait pas dans le html pour avoir une page valide).
function init() {
	canvas_ColorMap = document.createElement('canvas');
	canvas_ColorMap.height = 300 ;
	canvas_ColorMap.width = document.getElementById('maxIter').value*12.5;
	document.getElementById('canvasDiv_Map').appendChild(canvas_ColorMap);
	
	canvas_Fractal = document.createElement('canvas');
	canvas_Fractal.height = document.getElementById('iSizeY').value;
	canvas_Fractal.width = document.getElementById('iSizeX').value;
	canvas_Fractal.setAttribute('onmousedown', 'start(event);');
	document.getElementById('canvasDiv_Fractal').appendChild(canvas_Fractal);
	
	draw();
}

function MInMax255(inumber)
{
	while(inumber>254 || inumber<0)
	{
		if(inumber>254)
		{
			inumber= 254+(254 - inumber);
		}
		if(inumber<0)
		{
			inumber=-inumber;
		}
	}
	return	inumber;
}

function MakeRation2Frequency()
{
	var iA1 = document.getElementById('iA1n').value;
	var iA2 = document.getElementById('iA2n').value;
	var iA3 = document.getElementById('iA3n').value;
	
	iR1 = (document.getElementById('iR1n').value);
	iR2 = (document.getElementById('iR2n').value);
	iR3 = (document.getElementById('iR3n').value);
	if(iA1==0) {
		iR1=1;
	}
	if(iA2==0) {
		iR2=1;
	}
	if(iA3==0) {
		iR3=1;
	}
	
	
	var iR=0;
	var iRA=Math.max(iR1,iR2,iR3);
	var iRC=Math.min(iR1,iR2,iR3);
	var iRB=0;
	if(iRA==iRC)//Si iRi<>iRj
	{
		iRB=iR1;
	}
	else
	{
		if(iR1==iR2)
		{
			if(iR1==iRA)
			{
				iRB=iRA;
			}
			else
			{
				iRB=iRC;
			}
		}
		if(iR1==iR3)
		{
			if(iR1==iRA)
			{
				iRB=iRA;
			}
			else
			{
				iRB=iRC;
			}
		}
		if(iR3==iR2)
		{
			if(iR3==iRA)
			{
				iRB=iRA;
			}
			else
			{
				iRB=iRC;
			}
		}
		if(iR1!=iRA && iR1!=iRC)
		{
			iRB=iR1;
		}
		if(iR2!=iRA && iR2!=iRC)
		{
			iRB=iR2;
		}
		if(iR3!=iRA && iR3!=iRC)
		{
			iRB=iR3;
		}
	}
	iR=iRA*iRB*iRC;
	var d=2;
	while(d<=(iR/2+1))
	{
		if((iR/d) % iRA == 0 && (iR/d) % iRB == 0 && (iR/d) % iRC == 0)
		{
			iR=iR/d;
			d=2;
		}
		else
		{
			d++;
		}
	}
	
	PI=3.14159265359;
	var iNb = document.getElementById('iNbn').value;
	var iSize = document.getElementById('maxIter').value;
	//alert('iNb='+iNb+' (iNb/100.0)='+(iNb/100.0));
	var iWcible=2*PI*(iNb/100.0)/iSize;
	var iWreel=2*PI/iR;
	var icoef=iSize/((iNb/100.0)*iR);
	iF1=2*PI/(iR1*icoef);
	iF2=2*PI/(iR2*icoef);
	iF3=2*PI/(iR3*icoef);
}
//Colore map
function Color_map(len)
  {
    len=len;
	
	var frequency1=iF1;//0.3;
	var frequency2=iF2;//0.3;
	var frequency3=iF3;//0.3;
	
	var phase1 = (document.getElementById('iP1n').value/180)*PI;//0;
	var phase2 = (document.getElementById('iP2n').value/180)*PI;//2;
	var phase3 = (document.getElementById('iP3n').value/180)*PI;//4;
	
	var center=128;
	var iA1 = document.getElementById('iA1n').value;
	var iA2 = document.getElementById('iA2n').value;
	var iA3 = document.getElementById('iA3n').value;
	var iC1 = document.getElementById('iC1n').value;
	var iC2 = document.getElementById('iC2n').value;
	var iC3 = document.getElementById('iC3n').value;

    var i=len;

    var red = MInMax255(Math.floor((Math.sin(frequency1*i + phase1) * iA1*1.0))+iC1*1.0);
	var grn = MInMax255(Math.floor((Math.sin(frequency2*i + phase2) * iA2*1.0))+iC2*1.0);
	var blu = MInMax255(Math.floor((Math.sin(frequency3*i + phase3) * iA3*1.0))+iC3*1.0);
    //alert('iA1='+iA1+' phase3='+phase3+ 'red='+red);
	return Array(red,grn,blu);
  }
//////////////////////////////////////////// DRAW FRACTALE ////////////////////////////////////////////////////////////////

//Fonction permettant de convertir les coordonnées d'un point du canvas en des coordonnées de nombre complexe.
function coordComplex(coordXY, isX) {
	var PasX=iZoom/iSizeX;
	if(isX)
		return ((coordXY-(iSizeX/2))*PasX)+iCentX;
	return (((iSizeY/2)-coordXY)*PasX)+iCentY;
}
//Fonction permettant de déterminer si le nombre complexe correspondant à la position (x, y) appartient à l'ensemble de Mandelbrot.
function Mandelbrot(x, y) {
	
	var iter = 0;
	
	var zReal = 0;
	var zImag = 0;
	var zRealTmp = 0;
	
	var X_pos=coordComplex(x, true);
	var Y_pos=coordComplex(y, false);
	//alert('maxIter='+maxIter+' Y_pos='+Y_pos)
	
	var p=Math.sqrt((X_pos-(1/4))*(X_pos-(1/4))+Y_pos*Y_pos)
	var p2=p-2*p*p;
	
	var d=(X_pos+1)*(X_pos+1)+Y_pos*Y_pos;
	
	if (X_pos < p2 || d<1/16)
	{
		return maxIter;
	}
	
	
	while (zReal * zReal + zImag * zImag < 4 && iter <= maxIter) {
		zRealTmp = zReal;
		zReal = zReal * zReal - zImag * zImag + coordComplex(x, true);
		zImag = 2 * zRealTmp * zImag + coordComplex(y, false);
		iter++;
	}
	return iter;
}

//////////////////////////////////////////// DRAW FRACTALE ////////////////////////////////////////////////////////////////



//Dessine la fractale.
function draw() {
	
	if (canvas_ColorMap.getContext){
		//Get Value
		/*var iR1n = (document.getElementById('iR1n').value);
		var iR2n = (document.getElementById('iR2n').value);
		var iR3n = (document.getElementById('iR3n').value);
		
		var iP1n = (document.getElementById('iP1n').value);
		var iP2n = (document.getElementById('iP2n').value);
		var iP3n = (document.getElementById('iP3n').value);
		
		var iA1n = (document.getElementById('iA1n').value);
		var iA2n = (document.getElementById('iA2n').value);
		var iA3n = (document.getElementById('iA3n').value);
		
		var iC1n = (document.getElementById('iC1n').value);
		var iC2n = (document.getElementById('iC2n').value);
		var iC3n = (document.getElementById('iC3n').value);
		*/
		maxIter = (document.getElementById('maxIter').value);
		var iNbn = (document.getElementById('iNbn').value);
		
		MakeRation2Frequency();
		PI=3.14159265359;
		//peridicite();
		canvas_ColorMap.width = maxIter*12.5;
		canvas_ColorMap.height = 300;
		
		var ctx = canvas_ColorMap.getContext('2d');
		for(var x = 0; x < canvas_ColorMap.width; x++) {
			for(var y = 201; y < canvas_ColorMap.height; y++) {
				var color=Color_map(Math.floor(x/12.5))
				ctx.fillStyle = 'rgb(' + color[0] + ', ' + color[1] + ', ' + color[2]+ ')';
				ctx.fillRect(x, y, 1, 1);
			}
		}
		for(var x = 0; x < canvas_ColorMap.width; x++) {
			var color=Color_map(Math.floor(x/12.5))
			var R=Math.abs(190-(color[0]/255*180));
			var G=Math.abs(190-(color[1]/255*180));
			var B=Math.abs(190-(color[2]/255*180));
			var S=(R+B+G)/3;
			
			ctx.fillStyle = 'rgb(' + 255 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, R+1, 1, 1);
			ctx.fillStyle = 'rgb(' + 255 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, R, 1, 1);
			ctx.fillStyle = 'rgb(' + 255 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, R-1, 1, 1);
			
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 250 + ', ' + 0 + ')';
			ctx.fillRect(x, G-1, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 250 + ', ' + 0 + ')';
			ctx.fillRect(x, G, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 250 + ', ' + 0 + ')';
			ctx.fillRect(x, G+1, 1, 1);
			
			
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 255 + ')';
			ctx.fillRect(x, B+1, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 255 + ')';
			ctx.fillRect(x, B, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 255 + ')';
			ctx.fillRect(x, B-1, 1, 1);
			
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, S+1, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, S, 1, 1);
			ctx.fillStyle = 'rgb(' + 0 + ', ' + 0 + ', ' + 0 + ')';
			ctx.fillRect(x, S-1, 1, 1);
			
		}
		
		// save canvas image as data url (png format by default)
		var dataURL = canvas_ColorMap.toDataURL();

		// set canvasImg image src to dataURL
		// so it can be saved as an image
		document.getElementById('canvasDiv_Map').src = dataURL;
	
	} 
	if (canvas_Fractal.getContext){	
		iCentX = parseFloat(document.getElementById('iCentX').value);
		iCentY = parseFloat(document.getElementById('iCentY').value);
		iZoom = parseFloat(document.getElementById('iZoom').value);
		iSizeX = document.getElementById('iSizeX').value;
		iSizeY = document.getElementById('iSizeY').value;
		maxIter = document.getElementById('maxIter').value;
		var width = iSizeX;
		var height = iSizeY;
		
		//alert('width='+width+', height='+height);
				
		canvas_Fractal.width = width;
		canvas_Fractal.height = height;
		
		var ctx = canvas_Fractal.getContext('2d');
		for(var x = 0; x < width; x++) {
			for(var y = 0; y < height; y++) {
				var iter = Mandelbrot(x, y);
				//Si il existe |Zn|² < 4, le nombre complexe n'appartient pas à l'ensemble de Mandelbrot.
				//On détermine alors une couleur dépendant de iter.
				if (iter < maxIter) {
					var color=Color_map(iter)
					//alert(iter);
					ctx.fillStyle = 'rgb(' + color[0] + ', ' + color[1] + ', ' + color[2]+ ')';
				} else {
					ctx.fillStyle = '#000000';
				}
				ctx.fillRect(x, y, 1, 1);
			}
		}
		
		document.getElementById("dl").addEventListener('click', dlCanvas, false);
	}
		var now = new Date();
	var Name_date=now.getFullYear()+'_'+(now.getMonth()+1)+'_'+now.getDate()+'_'+now.getHours()+'h_'+now.getMinutes()+'min_'+now.getSeconds()+'s_'+now.getMilliseconds()+'ms';
	var d = document.getElementById("d");
	d.innerHTML='python Fractal.py -Mandelbrot -f1 '+iF1+' -f2 '+iF2+' -f3 '+iF3+' -p1 '+iP1+' -p2 '+iP2+' -p3 '+iP3+' -centerx ' +iCentX+' -centery '+iCentY+' -sizex '+iSizeX+' -sizey '+iSizeY+' -intermax '+maxIter+' -zoom '+iZoom+' -o '+Name_date;
}
//////////////////////////////////////////// MOVE IN FRACTALE ///////////////////////////////////////////////////////////////
//Récupère la position de la souris dès l'appui sur un bouton de la souris.
function start(e) {
	if(e.button != 2) {
		pressed = true;
	}
}
//Zoome sur la fractale lors du relâchement de la souris.
function stop(e) {
	if(pressed) {
		document.getElementById('iCentX').value= coordComplex(e.pageX - canvas_Fractal.offsetLeft, true);
		document.getElementById('iCentY').value =coordComplex(e.pageY - canvas_Fractal.offsetTop, false);
		document.getElementById('iZoom').value=parseFloat(document.getElementById('iZoom').value)/2;
		pressed = false;
		//alert('pressed='+pressed);
		draw();
		
	}
	//alert(e)
}
//////////////////////////////////////////// MOVE IN FRACTALE ///////////////////////////////////////////////////////////////

//////////////////////////////////////////// DoNWLAUD IN FRACTALE ///////////////////////////////////////////////////////////////

function dlCanvas() {
	var dt = canvas_Fractal.toDataURL('image/png');
	/* Change MIME type to trick the browser to downlaod the file instead of displaying it */
	dt = dt.replace(/^data:image\/[^;]*/, 'data:application/octet-stream');

	/* In addition to <a>'s "download" attribute, you can define HTTP-style headers */
	dt = dt.replace(/^data:application\/octet-stream/, 'data:application/octet-stream;headers=Content-Disposition%3A%20attachment%3B%20filename=Canvas.png');
	
	this.href = dt;
};

//////////////////////////////////////////// DoNWLAUD IN FRACTALE ///////////////////////////////////////////////////////////////
