function HelloWorld() {
    alert('Hello World!');
};

document.getElementById("hw-button").addEventListener("click", function(){
    console.log("clicked");
});

document.getElementById("hw-button").addEventListener("click", HelloWorld);

