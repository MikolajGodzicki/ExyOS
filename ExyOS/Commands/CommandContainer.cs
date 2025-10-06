namespace ExyOS.Commands {
    internal class CommandContainer {
        public static Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        
        public CommandContainer() {
            Initialize();
        }

        private void Initialize() {
            commands["whoami"] = new _WhoAmI();
            commands["clear"] = new _Clear();
            commands["cd"] = new _Cd();
            commands["ls"] = new _Ls();
            commands["cat"] = new _Cat();
            commands["touch"] = new _Touch();
            commands["exit"] = new _Exit();
            commands["rm"] = new _Rm();
            commands["exyTE"] = new _ExyTE();
            commands["help"] = new _Help();
        }
    }
}
