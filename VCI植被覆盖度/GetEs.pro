;;获取Eλ大气层外平均太阳光谱辐照度
pro GetEs,inputSensor,inBandNum,otEs 

  gf1_pms1_irradiance = [1371.53d,1944.98d,1854.42d,1542.63d,1080.81d]
  gf1_pms2_irradiance = [1376.10d,1945.34d,1854.15d,1543.62d,1081.93d]
  gf1_wfv1_irradiance = [1968.66d,1849.43d,1570.88d,1078.97d]
  gf1_wfv2_irradiance = [1955.02d,1847.56d,1568.89d,1087.96d]
  gf1_wfv3_irradiance = [1956.54d,1840.78d,1540.95d,1083.98d]
  gf1_wfv4_irradiance = [1968.12d,1841.69d,1540.30d,1069.53d]

  IF STRCMP(inputSensor,'PMS1') eq 1 then otEs = gf1_pms1_irradiance[inBandNum-1]
  IF STRCMP(inputSensor,'PMS1') eq 1 then otEs = gf1_pms2_irradiance[inBandNum-1]
  IF STRCMP(inputSensor,'WFV1') eq 1 then otEs = gf1_wfv1_irradiance[inBandNum-1]
  IF STRCMP(inputSensor,'WFV2') eq 1 then otEs = gf1_wfv2_irradiance[inBandNum-1]
  IF STRCMP(inputSensor,'WFV3') eq 1 then otEs = gf1_wfv3_irradiance[inBandNum-1]
  IF STRCMP(inputSensor,'WFV4') eq 1 then otEs = gf1_wfv4_irradiance[inBandNum-1]

end