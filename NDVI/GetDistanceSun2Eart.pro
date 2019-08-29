;;计算日地距离
pro GetDistanceSun2Earth,inDays,otdisSun2Earth

  otdisSun2Earth = 1+0.0167*sin(2*!pi*(inDays-93.5)/365)

end