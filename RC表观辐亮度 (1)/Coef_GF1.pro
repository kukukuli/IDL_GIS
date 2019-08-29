;;获取增益值和偏移量，用于计算表观辐亮度
Pro Coef_GF1,inSensor,inYear,inBandNum,otGain,otOffset
  ; gain and offset - 2013[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2013 = [0.1886d,0.2082d,0.1672d,0.1748d,0.1883d]
  gf1_pms2_gain_2013 = [0.1878d,0.2072d,0.1776d,0.1770d,0.1909d]
  gf1_pms1_offset_2013 = [-13.1270d,4.6186d,4.8768d,4.8924d,-9.4771d]
  gf1_pms2_offset_2013 = [-7.9731d,7.5348d,3.9395d,-1.7445d,-7.2053d]

  ; gain and offset - 2014[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2014 = [0.1963d,0.2247d,0.1892d,0.1889d,0.1939d]
  gf1_pms2_gain_2014 = [0.2147d,0.2419d,0.2047d,0.2009d,0.2058d]
  gf1_pms1_offset_2014 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]
  gf1_pms2_offset_2014 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]

  ; gain and offset - 2015[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2015 = [0.1956d,0.2110d,0.1802d,0.1806d,0.1870d]
  gf1_pms2_gain_2015 = [0.2018d,0.2242d,0.1887d,0.1882d,0.1963d]
  gf1_pms1_offset_2015 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]
  gf1_pms2_offset_2015 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]

  ; gain and offset - 2016[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2016 = [0.1956d,0.2110d,0.1802d,0.1806d,0.1870d]
  gf1_pms2_gain_2016 = [0.2018d,0.2242d,0.1887d,0.1882d,0.1963d]
  gf1_pms1_offset_2016 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]
  gf1_pms2_offset_2016 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]

  ; gain and offset - 2017[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2017 = [0.1956d,0.2110d,0.1802d,0.1806d,0.1870d]
  gf1_pms2_gain_2017 = [0.2018d,0.2242d,0.1887d,0.1882d,0.1963d]
  gf1_pms1_offset_2017 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]
  gf1_pms2_offset_2017 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]

  ; gain and offset - 2018[pan, band1, band2, band3, band4]
  gf1_pms1_gain_2018 = [0.1956d,0.2110d,0.1802d,0.1806d,0.1870d]
  gf1_pms2_gain_2018 = [0.2018d,0.2242d,0.1887d,0.1882d,0.1963d]
  gf1_pms1_offset_2018 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]
  gf1_pms2_offset_2018 = [0.0000d,0.0000d,0.0000d,0.0000d,0.0000d]

  ; gain and offset - 2013
  gf1_wfv1_gain_2013 = [0.1709d,0.1398d,0.1195d,0.1338d]
  gf1_wfv2_gain_2013 = [0.1588d,0.1515d,0.1251d,0.1209d]
  gf1_wfv3_gain_2013 = [0.1556d,0.1700d,0.1392d,0.1354d]
  gf1_wfv4_gain_2013 = [0.1819d,0.1762d,0.1463d,0.1522d]
  gf1_wfv1_offset_2013 = [-0.0039d,-0.0047d,-0.0030d,-0.0274d]
  gf1_wfv2_offset_2013 = [5.5303d,-13.6420d,-15.382d,-7.9850d]
  gf1_wfv3_offset_2013 = [12.2800d,-7.9336d,-7.0301d,-4.3578d]
  gf1_wfv4_offset_2013 = [3.6469d,-13.5400d,-10.998d,-12.142d]


  ; gain and offset - 2014
  gf1_wfv1_gain_2014 = [0.2004d,0.1648d,0.1243d,0.1563d]
  gf1_wfv2_gain_2014 = [0.1733d,0.1383d,0.1122d,0.1391d]
  gf1_wfv3_gain_2014 = [0.1745d,0.1514d,0.1257d,0.1462d]
  gf1_wfv4_gain_2014 = [0.1713d,0.1600d,0.1497d,0.1435d]
  gf1_wfv1_offset_2014 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv2_offset_2014 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv3_offset_2014 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv4_offset_2014 = [0.0000d,0.0000d, 0.0000d, 0.0000d]

  ; gain and offset - 2015
  gf1_wfv1_gain_2015 = [0.1816d,0.1560d,0.1412d,0.1368d]
  gf1_wfv2_gain_2015 = [0.1684d,0.1527d,0.1373d,0.1263d]
  gf1_wfv3_gain_2015 = [0.1770d,0.1589d,0.1385d,0.1344d]
  gf1_wfv4_gain_2015 = [0.1886d,0.1645d,0.1467d,0.1378d]
  gf1_wfv1_offset_2015 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv2_offset_2015 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv3_offset_2015 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv4_offset_2015 = [0.0000d,0.0000d, 0.0000d, 0.0000d]

  ; gain and offset - 2016
  gf1_wfv1_gain_2016 = [0.1816d,0.1560d,0.1412d,0.1368d]
  gf1_wfv2_gain_2016 = [0.1684d,0.1527d,0.1373d,0.1263d]
  gf1_wfv3_gain_2016 = [0.1770d,0.1589d,0.1385d,0.1344d]
  gf1_wfv4_gain_2016 = [0.1886d,0.1645d,0.1467d,0.1378d]
  gf1_wfv1_offset_2016 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv2_offset_2016 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv3_offset_2016 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv4_offset_2016 = [0.0000d,0.0000d, 0.0000d, 0.0000d]

  ; gain and offset - 2017
  gf1_wfv1_gain_2017 = [0.1816d,0.1560d,0.1412d,0.1368d]
  gf1_wfv2_gain_2017 = [0.1684d,0.1527d,0.1373d,0.1263d]
  gf1_wfv3_gain_2017 = [0.1770d,0.1589d,0.1385d,0.1344d]
  gf1_wfv4_gain_2017 = [0.1886d,0.1645d,0.1467d,0.1378d]
  gf1_wfv1_offset_2017 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv2_offset_2017 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv3_offset_2017 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv4_offset_2017 = [0.0000d,0.0000d, 0.0000d, 0.0000d]

  ; gain and offset - 2018
  gf1_wfv1_gain_2018 = [0.1816d,0.1560d,0.1412d,0.1368d]
  gf1_wfv2_gain_2018 = [0.1684d,0.1527d,0.1373d,0.1263d]
  gf1_wfv3_gain_2018 = [0.1770d,0.1589d,0.1385d,0.1344d]
  gf1_wfv4_gain_2018 = [0.1886d,0.1645d,0.1467d,0.1378d]
  gf1_wfv1_offset_2018 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv2_offset_2018 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv3_offset_2018 = [0.0000d,0.0000d, 0.0000d, 0.0000d]
  gf1_wfv4_offset_2018 = [0.0000d,0.0000d, 0.0000d, 0.0000d]

  ;;2013
  if inYear eq 2013 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2013[inBandNum-1]
      otOffset = gf1_pms1_offset_2013[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2013[inBandNum-1]
      otOffset = gf1_pms2_offset_2013[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2013[inBandNum-1]
      otOffset = gf1_wfv1_offset_2013[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2013[inBandNum-1]
      otOffset = gf1_wfv2_offset_2013[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2013[inBandNum-1]
      otOffset = gf1_wfv3_offset_2013[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2013[inBandNum-1]
      otOffset = gf1_wfv4_offset_2013[inBandNum-1]
    endif
  endif

  ;;2014
  if inYear eq 2014 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2014[inBandNum-1]
      otOffset = gf1_pms1_offset_2014[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2014[inBandNum-1]
      otOffset = gf1_pms2_offset_2014[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2014[inBandNum-1]
      otOffset = gf1_wfv1_offset_2014[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2014[inBandNum-1]
      otOffset = gf1_wfv2_offset_2014[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2014[inBandNum-1]
      otOffset = gf1_wfv3_offset_2014[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2014[inBandNum-1]
      otOffset = gf1_wfv4_offset_2014[inBandNum-1]
    endif
  endif

  ;;2015
  if inYear eq 2015 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2015[inBandNum-1]
      otOffset = gf1_pms1_offset_2015[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2015[inBandNum-1]
      otOffset = gf1_pms2_offset_2015[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2015[inBandNum-1]
      otOffset = gf1_wfv1_offset_2015[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2015[inBandNum-1]
      otOffset = gf1_wfv2_offset_2015[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2015[inBandNum-1]
      otOffset = gf1_wfv3_offset_2015[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2015[inBandNum-1]
      otOffset = gf1_wfv4_offset_2015[inBandNum-1]
    endif
  endif

  ;;2016
  if inYear eq 2016 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2016[inBandNum-1]
      otOffset = gf1_pms1_offset_2016[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2016[inBandNum-1]
      otOffset = gf1_pms2_offset_2016[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2016[inBandNum-1]
      otOffset = gf1_wfv1_offset_2016[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2016[inBandNum-1]
      otOffset = gf1_wfv2_offset_2016[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2016[inBandNum-1]
      otOffset = gf1_wfv3_offset_2016[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2016[inBandNum-1]
      otOffset = gf1_wfv4_offset_2016[inBandNum-1]
    endif
  endif

  ;;2017
  if inYear eq 2017 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2017[inBandNum-1]
      otOffset = gf1_pms1_offset_2017[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2017[inBandNum-1]
      otOffset = gf1_pms2_offset_2017[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2017[inBandNum-1]
      otOffset = gf1_wfv1_offset_2017[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2017[inBandNum-1]
      otOffset = gf1_wfv2_offset_2017[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2017[inBandNum-1]
      otOffset = gf1_wfv3_offset_2017[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2017[inBandNum-1]
      otOffset = gf1_wfv4_offset_2017[inBandNum-1]
    endif
  endif

  ;;2018
  if inYear eq 2018 then begin
    if strcmp(inSensor, 'PMS1') then begin
      otGain = gf1_pms1_gain_2018[inBandNum-1]
      otOffset = gf1_pms1_offset_2018[inBandNum-1]
    endif
    if strcmp(inSensor, 'PMS2') then begin
      otGain = gf1_pms2_gain_2018[inBandNum-1]
      otOffset = gf1_pms2_offset_2018[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV1') then begin
      otGain = gf1_wfv1_gain_2018[inBandNum-1]
      otOffset = gf1_wfv1_offset_2018[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV2') then begin
      otGain = gf1_wfv2_gain_2018[inBandNum-1]
      otOffset = gf1_wfv2_offset_2018[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV3') then begin
      otGain = gf1_wfv3_gain_2018[inBandNum-1]
      otOffset = gf1_wfv3_offset_2018[inBandNum-1]
    endif
    if strcmp(inSensor, 'WFV4') then begin
      otGain = gf1_wfv4_gain_2018[inBandNum-1]
      otOffset = gf1_wfv4_offset_2018[inBandNum-1]
    endif
  endif

end