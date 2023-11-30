
public interface IState
{
    //状态进入
    void Enter();

    //状态退出
    void Exit();
    //状态逻辑更新
    void LogicUpdate();
    //状态物理更新
    void PhysicUpdate();
}
