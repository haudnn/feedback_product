//tagline(true, 'Đây là đoạn nội dung mẫu để kiểm tra giao diện');
function tagline(success, message, override = false) {
  if (!message) return;

  taglineHide();
  const notify = document.createElement('div');
  notify.id = 'notify';
  notify.innerHTML = `
    <div class="notification is-${success ? 'success' : 'danger'}">
      <a class="delete" onclick="taglineHide()"></a>
      <p>${message}</p>
    </div>`;
  document.querySelector('body').appendChild(notify);

  if (success) console.warn('[Tagline]' + message);
  else console.error('[Tagline]' + message);

  if (!override) {
    setTimeout(function () {
      if (notify !== null) notify.remove();
    }, 8000);
  }
}

function taglineHide() {
  const notify = document.querySelector('#notify');
  if (notify !== null) notify.remove();
}
