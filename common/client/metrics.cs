exec("~/ui/FrameOverlayGui.gui");
function fpsMetricsCallback()
{
    return " FPS: " @ $FPS::real @ "  mspf: " @ 1000 / $FPS::real;
    return ;
}
function keyboardMetricsCallback()
{
    return "  modifiers: " @ $Keyboard::modifierKeys;
    return ;
}
function terrainMetricsCallback()
{
    return fpsMetricsCallback() @ "  Terrain -" @ "  L0: " @ $T2::levelZeroCount @ "  FMC: " @ $T2::fullMipCount @ "  DTC: " @ $T2::dynamicTextureCount @ "  UNU: " @ $T2::unusedTextureCount @ "  STC: " @ $T2::staticTextureCount @ "  DTSU: " @ $T2::textureSpaceUsed @ "  STSU: " @ $T2::staticTSU @ "  FRB: " @ $T2::FogRejections;
    return ;
}
function videoMetricsCallback()
{
    return fpsMetricsCallback() @ "  Video -" @ "  TC: " @ (($OpenGL::triCount0 + $OpenGL::triCount1) + $OpenGL::triCount2) + $OpenGL::triCount3 @ "  PC: " @ (($OpenGL::primCount0 + $OpenGL::primCount1) + $OpenGL::primCount2) + $OpenGL::primCount3 @ "  T_T: " @ $OpenGL::triCount1 @ "  T_P: " @ $OpenGL::primCount1 @ "  I_T: " @ $OpenGL::triCount2 @ "  I_P: " @ $OpenGL::primCount2 @ "  TS_T: " @ $OpenGL::triCount3 @ "  TS_P: " @ $OpenGL::primCount3 @ "  ?_T: " @ $OpenGL::triCount0 @ "  ?_P: " @ $OpenGL::primCount0;
    return ;
}
function interiorMetricsCallback()
{
    return fpsMetricsCallback() @ "  Interior --" @ "  NTL: " @ $Video::numTexelsLoaded @ "  TRP: " @ $Video::texResidentPercentage @ "  INP: " @ $Metrics::Interior::numPrimitives @ "  INT: " @ $Matrics::Interior::numTexturesUsed @ "  INO: " @ $Metrics::Interior::numInteriors;
    return ;
}
function textureMetricsCallback()
{
    return fpsMetricsCallback() @ "  Texture --" @ "  NTL: " @ $Video::numTexelsLoaded @ "  TRP: " @ $Video::texResidentPercentage @ "  TCM: " @ $Video::textureCacheMisses;
    return ;
}
function waterMetricsCallback()
{
    return fpsMetricsCallback() @ "  Water --" @ "  Tri#: " @ $T2::waterTriCount @ "  Pnt#: " @ $T2::waterPointCount @ "  Hz#: " @ $T2::waterHazePointCount;
    return ;
}
function timeMetricsCallback()
{
    return fpsMetricsCallback() @ "  Time -- " @ "  Sim Time: " @ getSimTime() @ "  Mod: " @ getSimTime() % 32;
    return ;
}
function vehicleMetricsCallback()
{
    return fpsMetricsCallback() @ "  Vehicle --" @ "  R: " @ $Vehicle::retryCount @ "  C: " @ $Vehicle::searchCount @ "  P: " @ $Vehicle::polyCount @ "  V: " @ $Vehicle::vertexCount;
    return ;
}
function audioMetricsCallback()
{
    return fpsMetricsCallback() @ "  Audio --" @ " OH:  " @ $Audio::numOpenHandles @ " OLH: " @ $Audio::numOpenLoopingHandles @ " AS:  " @ $Audio::numActiveStreams @ " NAS: " @ $Audio::numNullActiveStreams @ " LAS: " @ $Audio::numActiveLoopingStreams @ " LS:  " @ $Audio::numLoopingStreams @ " ILS: " @ $Audio::numInactiveLoopingStreams @ " CLS: " @ $Audio::numCulledLoopingStreams;
    return ;
}
function debugMetricsCallback()
{
    return fpsMetricsCallback() @ "  Debug --" @ "  NTL: " @ $Video::numTexelsLoaded @ "  TRP: " @ $Video::texResidentPercentage @ "  NP:  " @ $Metrics::numPrimitives @ "  NT:  " @ $Metrics::numTexturesUsed @ "  NO:  " @ $Metrics::numObjectsRendered;
    return ;
}
$metricsNamesList = "";
$metricsNamesList = $metricsNamesList @ "audio";
$metricsNamesList = $metricsNamesList SPC "debug";
$metricsNamesList = $metricsNamesList SPC "fps";
$metricsNamesList = $metricsNamesList SPC "interior";
$metricsNamesList = $metricsNamesList SPC "keyboard";
$metricsNamesList = $metricsNamesList SPC "none";
$metricsNamesList = $metricsNamesList SPC "time";
$metricsNamesList = $metricsNamesList SPC "terrain";
$metricsNamesList = $metricsNamesList SPC "texture";
$metricsNamesList = $metricsNamesList SPC "vehicle";
$metricsNamesList = $metricsNamesList SPC "video";
$metricsNamesList = $metricsNamesList SPC "water";
function metrics(%expr)
{
    %cb = "";
    if (%expr $= "audio")
    {
        %cb = "audioMetricsCallback()";
    }
    else
    {
        if (%expr $= "debug")
        {
            %cb = "debugMetricsCallback()";
        }
        else
        {
            if (%expr $= "interior")
            {
                $fps::virtual = 0;
                $Interior::numPolys = 0;
                $Interior::numTextures = 0;
                $Interior::numTexels = 0;
                $Interior::numLightmaps = 0;
                $Interior::numLumels = 0;
                %cb = "interiorMetricsCallback()";
            }
            else
            {
                if (%expr $= "fps")
                {
                    %cb = "fpsMetricsCallback()";
                }
                else
                {
                    if (%expr $= "keyboard")
                    {
                        %cb = "keyboardMetricsCallback()";
                    }
                    else
                    {
                        if (%expr $= "time")
                        {
                            %cb = "timeMetricsCallback()";
                        }
                        else
                        {
                            if (%expr $= "terrain")
                            {
                                %cb = "terrainMetricsCallback()";
                            }
                            else
                            {
                                if (%expr $= "texture")
                                {
                                    GLEnableMetrics(1);
                                    %cb = "textureMetricsCallback()";
                                }
                                else
                                {
                                    if (%expr $= "video")
                                    {
                                        %cb = "videoMetricsCallback()";
                                    }
                                    else
                                    {
                                        if (%expr $= "vehicle")
                                        {
                                            %cb = "vehicleMetricsCallback()";
                                        }
                                        else
                                        {
                                            if (%expr $= "water")
                                            {
                                                %cb = "waterMetricsCallback()";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    if (!(%cb $= ""))
    {
        Canvas.pushDialog(FrameOverlayGui, 1000);
        TextOverlayControl.setValue(%cb);
    }
    else
    {
        GLEnableMetrics(0);
        Canvas.popDialog(FrameOverlayGui);
    }
    return ;
}
