import "./Right.scss";

function Right() {
  return (
    <div className="right">
      <iframe
        title="unique title"
        src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2FObudaiEgyetem&tabs=timeline&width=340&height=1200&small_header=false&adapt_container_width=true&hide_cover=false&show_facepile=true&appId"
        width="340"
        height="800"
        style={{ border: "none", overflow: "hidden" }}
        scrolling="no"
        frameBorder="0"
        allowTransparency={true}
        allow="encrypted-media"
      ></iframe>
    </div>
  );
}

export default Right;
