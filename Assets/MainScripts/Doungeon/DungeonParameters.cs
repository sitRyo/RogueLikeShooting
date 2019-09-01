using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonConst {

    // ダンジョン生成用のパラメータ
    public static class DungeonParameters {
        // 後々増やせるようにする
        // 列挙型をreadonlyにしたい
        public enum parameters {
            Road,
            Wall,
        }
    }


}