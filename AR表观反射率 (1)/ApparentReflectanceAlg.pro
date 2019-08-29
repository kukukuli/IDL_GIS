;;表观反射率计算公式
Pro ApparentReflectanceAlg,inputAR,indisSun2Earth,inputEs,inputSunZenith,otAReflectance
 
  iSZA = inputSunZenith*!pi/180 ;;角度转化为弧度
  otAReflectance = !pi*inputAR*indisSun2Earth^2/(inputEs*cos(iSZA))

end