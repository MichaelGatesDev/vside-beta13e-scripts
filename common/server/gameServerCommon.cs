function onServerCreated()
{
    echo("in onServerCreated()");
    $Server::GameType = "Test App";
    $Server::MissionType = "Deathmatch";
    createGame();
    return ;
    return ;
}
function onServerDestroyed()
{
    destroyGame();
    return ;
    return ;
}
function onMissionLoaded()
{
    startGame();
    return ;
    return ;
}
function onMissionEnded()
{
    endGame();
    return ;
    return ;
}
function onMissionReset()
{
    return ;
    return ;
}
function GameConnection::onClientEnterGame(%unused)
{
    return ;
    return ;
}
function GameConnection::onClientLeaveGame(%unused)
{
    return ;
    return ;
}
function createGame()
{
    return ;
    return ;
}
function destroyGame()
{
    return ;
    return ;
}
function startGame()
{
    return ;
    return ;
}
function endGame()
{
    return ;
    return ;
}
