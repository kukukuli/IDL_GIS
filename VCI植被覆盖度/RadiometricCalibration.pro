;;辐射定标计算公式
pro RadiometricCalibration,inputData, inGain,iniBias,outRCData

  outRCData = inputData*inGain + iniBias

end