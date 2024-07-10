## Markdown 和快捷键全覆盖
> 💡 Tips：语雀支持全功能 markdown 语法，可以点击文档编辑页右下角小键盘查看全部支持的语法和快捷键。

- 支持导入导出 `markdown` 文件。
- 支持自动识别粘贴的 `markdown` 格式内容转换为富文本。
## 行内代码
> 💡 Tips：可通过 markdown 语法（```+ `code` + ``` + `空格`）或者快捷键 `ctrl/cmd` + `E`快速插入行内代码。

在文本中使用`行内代码`，可以顺畅地显示代码变量名。
## 代码块
> 💡 Tips：输入`/代码块`或点击上方工具栏点击上方工具栏![image.png](https://cdn.nlark.com/yuque/0/2022/png/519985/1646896088287-c8e7ef6c-2748-40d7-b53f-223b99fc5be5.png#averageHue=%23b1e5c6&clientId=u8726e0a6-b55e-4&from=paste&height=22&id=EuV2b&originHeight=22&originWidth=21&originalType=binary&ratio=1&rotation=0&showTitle=false&size=352&status=done&style=none&taskId=u6adeff07-b08f-4f2a-9a78-84bebd06c32&title=&width=21)，选择「代码块」、插入代码卡片。

代码块同时支持多种颜色主题：
```javascript
export default class QuickSort extends Sort {
  sort(originalArray) {
    const array = [...originalArray];

    if (array.length <= 1) {
      return array;
    }

    // Init left and right arrays.
    const leftArray = [];
    const rightArray = [];

    // Take the first element of array as a pivot.
    const pivotElement = array.shift();
    const centerArray = [pivotElement];

    // Split all array elements between left, center and right arrays.
    while (array.length) {
      const currentElement = array.shift();

      // Call visiting callback.
      this.callbacks.visitingCallback(currentElement);

      if (this.comparator.equal(currentElement, pivotElement)) {
        centerArray.push(currentElement);
      } else if (this.comparator.lessThan(currentElement, pivotElement)) {
        leftArray.push(currentElement);
      } else {
        rightArray.push(currentElement);
      }
    }
    // Sort left and right arrays.
    const leftArraySorted = this.sort(leftArray);
    const rightArraySorted = this.sort(rightArray);

    return leftArraySorted.concat(centerArray, rightArraySorted);
  }
}
```
```javascript
export default class QuickSort extends Sort {
  sort(originalArray) {
    const array = [...originalArray];

    if (array.length <= 1) {
      return array;
    }

    // Init left and right arrays.
    const leftArray = [];
    const rightArray = [];

    // Take the first element of array as a pivot.
    const pivotElement = array.shift();
    const centerArray = [pivotElement];

    // Split all array elements between left, center and right arrays.
    while (array.length) {
      const currentElement = array.shift();

      // Call visiting callback.
      this.callbacks.visitingCallback(currentElement);

      if (this.comparator.equal(currentElement, pivotElement)) {
        centerArray.push(currentElement);
      } else if (this.comparator.lessThan(currentElement, pivotElement)) {
        leftArray.push(currentElement);
      } else {
        rightArray.push(currentElement);
      }
    }
    // Sort left and right arrays.
    const leftArraySorted = this.sort(leftArray);
    const rightArraySorted = this.sort(rightArray);

    return leftArraySorted.concat(centerArray, rightArraySorted);
  }
}
```
```javascript
export default class QuickSort extends Sort {
  sort(originalArray) {
    const array = [...originalArray];

    if (array.length <= 1) {
      return array;
    }

    // Init left and right arrays.
    const leftArray = [];
    const rightArray = [];

    // Take the first element of array as a pivot.
    const pivotElement = array.shift();
    const centerArray = [pivotElement];

    // Split all array elements between left, center and right arrays.
    while (array.length) {
      const currentElement = array.shift();

      // Call visiting callback.
      this.callbacks.visitingCallback(currentElement);

      if (this.comparator.equal(currentElement, pivotElement)) {
        centerArray.push(currentElement);
      } else if (this.comparator.lessThan(currentElement, pivotElement)) {
        leftArray.push(currentElement);
      } else {
        rightArray.push(currentElement);
      }
    }
    // Sort left and right arrays.
    const leftArraySorted = this.sort(leftArray);
    const rightArraySorted = this.sort(rightArray);

    return leftArraySorted.concat(centerArray, rightArraySorted);
  }
}
```
## 数学公式
> 💡 Tips：输入 `/公式`或点击上方工具栏点击上方工具栏![image.png](https://cdn.nlark.com/yuque/0/2022/png/519985/1646896088287-c8e7ef6c-2748-40d7-b53f-223b99fc5be5.png#averageHue=%23b1e5c6&clientId=u8726e0a6-b55e-4&from=paste&height=22&id=Y49Cp&originHeight=22&originWidth=21&originalType=binary&ratio=1&rotation=0&showTitle=false&size=352&status=done&style=none&taskId=u6adeff07-b08f-4f2a-9a78-84bebd06c32&title=&width=21)，选择「公式」、插入公式卡片。

公式支持行内嵌套：![](https://intranetproxy.alipay.com/skylark/lark/__latex/8986e6bf4f4b4ff45d88debcfd9615ca.svg#card=math&code=c%20%3D%20%5Cpm%5Csqrt%7Ba%5E2%20%2B%20b%5E2%7D&id=pBGK4)，也支持块级嵌入。
![](https://intranetproxy.alipay.com/skylark/lark/__latex/45d276c520dbdf5bf9f9f3e4a7e5c480.svg#card=math&code=f%28x%29%3D%5Cint_%7B-%5Cinfty%7D%5E%5Cinfty%5Cwidehat%20f%5Cxi%5C%2Ce%5E%7B2%5Cpi%20i%5Cxi%20x%7D%5C%2Cd%5Cxi%0A&id=FMYMS)
## 画板
> 💡 Tips：输入`/画板`或点击上方工具栏![image.png](https://cdn.nlark.com/yuque/0/2022/png/519985/1646896088287-c8e7ef6c-2748-40d7-b53f-223b99fc5be5.png#averageHue=%23b1e5c6&clientId=u8726e0a6-b55e-4&from=paste&height=22&id=J4UvR&originHeight=22&originWidth=21&originalType=binary&ratio=1&rotation=0&showTitle=false&size=352&status=done&style=none&taskId=u6adeff07-b08f-4f2a-9a78-84bebd06c32&title=&width=21)，选择「画板」、绘制流程图、架构图等各种图形。

![](https://intranetproxy.alipay.com/skylark/lark/0/2022/jpeg/141/1643261198014-1b94d73a-8d53-416b-bc0e-05c2b61793ea.jpeg)
![](https://intranetproxy.alipay.com/skylark/lark/0/2022/jpeg/141/1643260172392-f825fb81-bb39-49eb-982b-2e1467396ba4.jpeg)

![](https://cdn.nlark.com/yuque/0/2022/jpeg/956523/1657187591568-621b44f9-81f7-4be7-8c31-257d7ec9ab0a.jpeg)
## 文本绘图
> 💡 Tips：输入`/文本绘图`点击上方工具栏![image.png](https://cdn.nlark.com/yuque/0/2022/png/519985/1646896088287-c8e7ef6c-2748-40d7-b53f-223b99fc5be5.png#averageHue=%23b1e5c6&clientId=u8726e0a6-b55e-4&from=paste&height=22&id=z0jSW&originHeight=22&originWidth=21&originalType=binary&ratio=1&rotation=0&showTitle=false&size=352&status=done&style=none&taskId=u6adeff07-b08f-4f2a-9a78-84bebd06c32&title=&width=21)，选择「文本绘图」、插入文本绘图卡片。
支持 [plantuml](https://plantuml.com/)、[mermaid](https://mermaid-js.github.io/mermaid/#/) 等多种格式，点击`预览`可看到图形。具体代码样式见[说明文档](https://www.yuque.com/yuque/gpvawt/gantt)。

![](https://intranetproxy.alipay.com/skylark/lark/__puml/b11b6192390c95750c4b71c2580ff529.svg#lake_card_v2=eyJ0eXBlIjoicHVtbCIsImNvZGUiOiJAc3RhcnR1bWxcblxuYXV0b251bWJlclxuXG5hY3RvciBcIueUqOaIt1wiIGFzIFVzZXJcbnBhcnRpY2lwYW50IFwi5rWP6KeI5ZmoXCIgYXMgQnJvd3NlclxucGFydGljaXBhbnQgXCLmnI3liqHnq69cIiBhcyBTZXJ2ZXIgI29yYW5nZVxuXG5hY3RpdmF0ZSBVc2VyXG5cblVzZXIgLT4gQnJvd3Nlcjog6L6T5YWlIFVSTFxuYWN0aXZhdGUgQnJvd3NlclxuXG5Ccm93c2VyIC0-IFNlcnZlcjog6K-35rGC5pyN5Yqh5ZmoXG5hY3RpdmF0ZSBTZXJ2ZXJcblxuU2VydmVyIC0-IFNlcnZlcjog5qih5p2_5riy5p-TXG5ub3RlIHJpZ2h0IG9mIFNlcnZlcjog6L-Z5piv5LiA5Liq5rOo6YeKXG5cblNlcnZlciAtPiBCcm93c2VyOiDov5Tlm54gSFRNTFxuZGVhY3RpdmF0ZSBTZXJ2ZXJcblxuQnJvd3NlciAtLT4gVXNlclxuXG5AZW5kdW1sIiwidXJsIjoiaHR0cHM6Ly9pbnRyYW5ldHByb3h5LmFsaXBheS5jb20vc2t5bGFyay9sYXJrL19fcHVtbC9iMTFiNjE5MjM5MGM5NTc1MGM0YjcxYzI1ODBmZjUyOS5zdmciLCJpZCI6Imd5WlBnIiwibWFyZ2luIjp7InRvcCI6dHJ1ZSwiYm90dG9tIjp0cnVlfSwiY2FyZCI6ImRpYWdyYW0ifQ==)![](https://lark-assets-test-aliyun.oss-cn-hangzhou.aliyuncs.com/yuque/__mermaid_v3/743010bfb6962498a4b9a485b60a8305.svg#lake_card_v2=eyJ0eXBlIjoibWVybWFpZCIsImNvZGUiOiJzZXF1ZW5jZURpYWdyYW1cbiAgICBwYXJ0aWNpcGFudCBKb2huXG4gICAgcGFydGljaXBhbnQgQWxpY2VcbiAgICBBbGljZS0-PkpvaG46IEhlbGxvIEpvaG4sIGhvdyBhcmUgeW91P1xuICAgIEpvaG4tLT4-QWxpY2U6IEdyZWF0ISIsInVybCI6Imh0dHBzOi8vbGFyay1hc3NldHMtdGVzdC1hbGl5dW4ub3NzLWNuLWhhbmd6aG91LmFsaXl1bmNzLmNvbS95dXF1ZS9fX21lcm1haWRfdjMvNzQzMDEwYmZiNjk2MjQ5OGE0YjlhNDg1YjYwYTgzMDUuc3ZnIiwiaWQiOiJLQXg5diIsIm1hcmdpbiI6eyJ0b3AiOnRydWUsImJvdHRvbSI6dHJ1ZX0sImNhcmQiOiJkaWFncmFtIn0=)
