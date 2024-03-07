export function registerOnlineStatusHandler(dotNetObjRef) {
    function onlineStatusHandler() {
        dotNetObjRef.invokeMethodAsync("SetOnlineStatusColor", navigator.onLine);
    }

    onlineStatusHandler(); //initial

    window.addEventListener("online", onlineStatusHandler);
    window.addEventListener("offline", onlineStatusHandler);
}