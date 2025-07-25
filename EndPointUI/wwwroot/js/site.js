document.addEventListener('DOMContentLoaded', function () {
    const chatIcon = document.querySelector('.chat-icon');
    const chatPopup = document.querySelector('.chat-popup');
    const closeChat = document.querySelector('.close-chat');
    const chatForm = document.getElementById('chat-form');
    const messageInput = document.getElementById('message-input');
    const chatMessages = document.querySelector('.chat-messages');

    // باز و بسته کردن پنجره چت
    chatIcon.addEventListener('click', function () {
        chatPopup.classList.add('active');
    });

    closeChat.addEventListener('click', function () {
        chatPopup.classList.remove('active');
    });

    // ارسال پیام
    chatForm.addEventListener('submit', function (e) {
        e.preventDefault();

        const message = messageInput.value.trim();
        if (message) {
            // افزودن پیام کاربر
            addMessage(message, 'user');
            messageInput.value = '';

            // شبیه‌سازی پاسخ پشتیبانی بعد از مدت کوتاهی
            setTimeout(function () {
                const responses = [
                    "ممنون از پیام شما. همکاران ما در اسرع وقت پاسخگو خواهند بود.",
                    "سپاس از تماس شما. چطور می‌توانم بیشتر کمک کنم؟",
                    "پیام شما دریافت شد. آیا سوال دیگری دارید؟",
                    "با تشکر از صبر شما. آیا اطلاعات بیشتری نیاز دارید؟"
                ];
                const randomResponse = responses[Math.floor(Math.random() * responses.length)];
                addMessage(randomResponse, 'support');
            }, 1000);
        }
    });

    // افزودن پیام به چت
    function addMessage(text, type) {
        const messageDiv = document.createElement('div');
        messageDiv.classList.add('message');
        messageDiv.classList.add(type === 'user' ? 'user-message' : 'support-message');
        messageDiv.textContent = text;

        chatMessages.appendChild(messageDiv);
        chatMessages.scrollTop = chatMessages.scrollHeight;
    }
});

(function () {
	function c() {
		var b = a.contentDocument || a.contentWindow.document;
		if (b) {
			var d = b.createElement('script');
			d.innerHTML = "window.__CF$cv$params={r:'94426e1ce31770d8',t:'MTc0Nzk4MTA0NS4wMDAwMDA='};var a=document.createElement('script');a.nonce='';a.src='/cdn-cgi/challenge-platform/scripts/jsd/main.js';document.getElementsByTagName('head')[0].appendChild(a);";
			b.getElementsByTagName('head')[0].appendChild(d)
		}
	}
	if (document.body) {
		var a = document.createElement('iframe');
		a.height = 1;
		a.width = 1;
		a.style.position = 'absolute';
		a.style.top = 0;
		a.style.left = 0;
		a.style.border = 'none';
		a.style.visibility = 'hidden';
		document.body.appendChild(a);
		if ('loading' !== document.readyState) c();
		else if (window.addEventListener) document.addEventListener('DOMContentLoaded', c);
		else {
			var e = document.onreadystatechange || function () { };
			document.onreadystatechange = function (b) {
				e(b);
				'loading' !== document.readyState && (document.onreadystatechange = e, c())
			}
		}
	}
})();


