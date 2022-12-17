luxy.init();
function videoUrl(el) {
    const aa = document.querySelectorAll("video");
    aa.forEach((el) => {
        el.classList.add("d-none");
        el.pause();
    });
    document.getElementById(el).classList.remove("d-none");
    document.getElementById(el).play();
}
$("li").click(function () {
    $("li").removeClass("svgcss");
    $(this).addClass("svgcss");
});
/*gsap*/
gsap.from("h1.hidden-text", { opacity: 0, duration: 1.5, y: 50 });
const options = {
    root: null,
    rootMargin: "200px",
    threshold: 0.9,
};

let revealCallback = (entries, self) => {
    entries.forEach((entry) => {
        let container = entry.target;
        let img = entry.target.querySelector("img");
        const easeInOut = "power3.out";
        const revealAnim = gsap.timeline({ ease: easeInOut });

        if (entry.isIntersecting) {
            revealAnim.set(container, {
                visibility: "visible",
            });
            revealAnim.fromTo(
                container,
                {
                    clipPath: "polygon(0 0, 0 0, 0 100%, 0% 100%)",
                    webkitClipPath: "polygon(0 0, 0 0, 0 100%, 0% 100%)",
                },
                {
                    clipPath: "polygon(0 0, 100% 0, 100% 100%, 0 100%)",
                    webkitClipPath: "polygon(0 0, 100% 0, 100% 100%, 0 100%)",
                    duration: 1,
                    ease: easeInOut,
                }
            );
            revealAnim.from(img, 4, {
                scale: 1.4,
                ease: easeInOut,
                delay: -1,
            });
            self.unobserve(entry.target);
        }
    });
};

let revealObserver = new IntersectionObserver(revealCallback, options);

document.querySelectorAll(".reveal").forEach((reveal) => {
    revealObserver.observe(reveal);
});