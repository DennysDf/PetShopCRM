signalRObject.execute('/Notification', function (connection) {
    connection.on('ReceiveNotification', function (userId, notificationType, message) {
        console.log(`Notificação para ${userId}: ${notificationType} - ${message}`);
    });
});
