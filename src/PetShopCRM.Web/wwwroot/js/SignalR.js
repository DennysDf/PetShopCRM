var signalRObject = {
    conected: false,
    execute: async function (hub, func) {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl(hub)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        this.base.connection = connection;

        try {
            await this.base.connection.start();

            console.log(`SignalR Connected on hub: ${hub}`);

            signalR.conected = true;

            func(this.base.connection);
        } catch (err) {
            console.log(err);
        }
    },
    base: {
        connection: null
    }
};